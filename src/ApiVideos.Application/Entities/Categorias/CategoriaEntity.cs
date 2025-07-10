using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Entities.Categorias;

public class CategoriaEntity : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public List<VideoEntity> Videos { get; set; } = [];
}
