namespace ApiVideos.Application.Entities;

public class VideosEntity
{
    public long Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
