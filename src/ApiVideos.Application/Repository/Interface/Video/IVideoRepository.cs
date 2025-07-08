namespace ApiVideos.Application.Repository.Interface.Video;

public interface IVideoRepository
{
    Task<List<VideosEntity>> GetByCategoriaIdAsync(long categoriaId, CancellationToken cancellationToken);
    Task<List<VideosEntity>> GetByTituloAsync(string? titulo, CancellationToken cancellationToken);
}
