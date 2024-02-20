using System.Linq.Expressions;

namespace Shared.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
{
    IQueryable<TEntity> SqlQuery(String sql, params object[] parameters);
    Int32 ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

    IQueryable<TEntity> All { get; }

    /// <summary>
    /// Get all entities from db based on filter, order and included properties
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Get single entity by primary key
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity Get(object id);

    /// <summary>
    /// Get single entity by primary key async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetAsync(object id);

    /// <summary>
    /// Insert entity to db
    /// </summary>
    /// <param name="entity"></param>
    void Insert(TEntity entity);

    /// <summary>
    /// Insert to db async
    /// </summary>
    /// <param name="entity"></param>
    Task InsertAsync(TEntity entity);

    /// <summary>
    /// Update entity in db
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

    /// <summary>
    /// Delete entity from db by primary key
    /// </summary>
    /// <param name="id"></param>
    void Delete(TEntity entity);
}
