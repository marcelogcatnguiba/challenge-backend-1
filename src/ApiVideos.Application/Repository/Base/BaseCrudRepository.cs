
using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Repository.Base;

public abstract class BaseCrudRepository<T>(ApiVideosContext context) : IRepository<T> where T : BaseEntity
{
    private readonly ApiVideosContext _context = context;
    private readonly DbSet<T> _dataSet = context.Set<T>();

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dataSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        _dataSet.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<T>> GetAsync(CancellationToken cancellationToken)
    {
        return await _dataSet.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await _dataSet
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken) ?? throw new ArgumentException("Registro não encontrado");

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        await GetByIdAsync(entity.Id, cancellationToken);

        _dataSet.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
