namespace ClaroTestBackend.Core.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> 
        where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
