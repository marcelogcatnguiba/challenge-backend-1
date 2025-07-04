namespace ApiVideos.Application.Entities.Categorias;

public class CategoriaEntity
{
    public long Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public List<VideosEntity> Videos { get; set; } = [];
}
