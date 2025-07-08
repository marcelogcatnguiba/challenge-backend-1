using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Endpoint.Interface;

public interface ICrudEndpoint<T> where T : BaseEntity
{
    static abstract Task<IResult> CreateAsync(T entity, IRepository<T> repository, IValidator<T> validator, CancellationToken cancellationToken);
    static abstract Task<IResult> UpdateAsync(T entity, IRepository<T> repository, CancellationToken cancellationToken);
    static abstract Task<IResult> DeleteAsync(long id, IRepository<T> repository, CancellationToken cancellationToken);
    static abstract Task<IResult> GetAsync(IRepository<T> repository, CancellationToken cancellationToken);
    static abstract Task<IResult> GetByIdAsync(long id, IRepository<T> repository, CancellationToken cancellationToken);
}
