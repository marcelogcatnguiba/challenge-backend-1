namespace ApiVideos.Application.Dtos.Videos;

public class VideoDto
{
    public long Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public long? CategoriaId { get; set; }
}
