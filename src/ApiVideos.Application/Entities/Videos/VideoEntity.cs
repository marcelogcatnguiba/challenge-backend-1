using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Entities.Videos;

public class VideoEntity : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public long? CategoriaId { get; set; }
    public CategoriaEntity? Categoria { get; set; }
}
