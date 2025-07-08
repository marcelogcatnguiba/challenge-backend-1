using System.Text.Json.Serialization;
using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Entities.Videos;

public class VideosEntity : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public long? CategoriaId { get; set; }

    [JsonIgnore]
    public CategoriaEntity? Categoria { get; set; }
}
