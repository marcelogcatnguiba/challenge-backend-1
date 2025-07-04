namespace ApiVideos.Application.Repository.Videos;

public class VideosRepository(ApiVideosContext context) : IRepository<VideosEntity>
{
    private readonly ApiVideosContext _context = context;

    public async Task CreateAsync(VideosEntity entity, CancellationToken cancellationToken)
    {
        await _context.Videos.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);   
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        _context.Videos.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<VideosEntity>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Videos.ToListAsync(cancellationToken);
    }

    public async Task<VideosEntity> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var video = await _context.Videos
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken) ?? throw new ArgumentException("Registro não encontrado");

        return video;
    }

    public async Task UpdateAsync(VideosEntity entity, CancellationToken cancellationToken)
    {
        await GetByIdAsync(entity.Id, cancellationToken);

        _context.Videos.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
