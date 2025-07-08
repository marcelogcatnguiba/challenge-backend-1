using ApiVideos.Application.Repository.Base;
using ApiVideos.Application.Repository.Interface.Video;

namespace ApiVideos.Application.Repository.Videos;

public class VideosRepository(ApiVideosContext context) : BaseCrudRepository<VideosEntity>(context), IVideoRepository
{
    public async Task<List<VideosEntity>> GetByCategoriaIdAsync(long categoriaId, CancellationToken cancellationToken)
    {
        return await _context.Videos.Where(x => x.CategoriaId.Equals(categoriaId)).ToListAsync(cancellationToken);
    }

    public async Task<List<VideosEntity>> GetByTituloAsync(string? titulo, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(titulo))
        {
            return [];
        }

        return await _context.Videos.Where(x => x.Titulo.Contains(titulo)).ToListAsync(cancellationToken);
    }
}
