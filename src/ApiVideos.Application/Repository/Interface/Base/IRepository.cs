using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Repository.Interface.Base;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken);
}
