using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context;

public class OnionContext : DbContext, IEntitiesContext
{
    private DbTransaction _transaction;

    public OnionContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        builder.AddEntityConfigurations(assembly);
        base.OnModelCreating(builder);
    }

    public void BeginTransaction()
    {
        if (this.Database.GetDbConnection().State == ConnectionState.Open)
        {
            return;
        }
        this.Database.GetDbConnection().Open();
        _transaction = this.Database.GetDbConnection().BeginTransaction();
    }

    public int Commit()
    {
        var saveChanges = SaveChanges();
        _transaction.Commit();
        return saveChanges;
    }

    public Task<int> CommitAsync()
    {
        var saveChangesAsync = SaveChangesAsync();
        _transaction.Commit();
        return saveChangesAsync;
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : EntityBase, new()
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) where TElement : class
        => base.Set<TElement>().FromSqlRaw(sql, parameters).AsEnumerable();

}