namespace ApiVideos.Application.Repository.Interface.Video;

public interface IVideoRepository
{
    Task<List<VideoEntity>> GetByCategoriaIdAsync(long categoriaId, CancellationToken cancellationToken);
    Task<List<VideoEntity>> GetByTituloAsync(string? titulo, CancellationToken cancellationToken);
}
