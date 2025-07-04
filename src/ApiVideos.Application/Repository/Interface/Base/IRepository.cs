namespace ApiVideos.Application.Repository.Interface.Base;

public interface IRepository<T>
{
    Task<List<T>> GetAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken);
}
