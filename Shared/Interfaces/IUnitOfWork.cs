namespace Shared.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    void Dispose(bool disposing);
    IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;
    void BeginTransaction();
    int Commit();
    void Rollback();
    Task<int> SaveChangesAsync();
    Task<int> CommitAsync();
}
