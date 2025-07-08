namespace ApiVideos.Application.Request.Videos;

public class VideosRequest
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public long? CategoriaId { get; set; }
}
