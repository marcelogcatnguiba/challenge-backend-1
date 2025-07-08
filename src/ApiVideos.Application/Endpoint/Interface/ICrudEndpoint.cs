using ApiVideos.Application.Entities.Base;
using AutoMapper;

namespace ApiVideos.Application.Endpoint.Interface;

public interface ICrudEndpoint<TEntity, TRequest> where TEntity : BaseEntity
{
    static abstract Task<IResult> CreateAsync(
        TRequest request,
        IRepository<TEntity> repository,
        IValidator<TEntity> validator,
        IMapper mapper,
        CancellationToken cancellationToken);

    static abstract Task<IResult> UpdateAsync(TRequest request, IRepository<TEntity> repository, IMapper mapper, CancellationToken cancellationToken);
    static abstract Task<IResult> DeleteAsync(long id, IRepository<TEntity> repository, CancellationToken cancellationToken);
    static abstract Task<IResult> GetAsync(IRepository<TEntity> repository, CancellationToken cancellationToken);
    static abstract Task<IResult> GetByIdAsync(long id, IRepository<TEntity> repository, CancellationToken cancellationToken);
}
