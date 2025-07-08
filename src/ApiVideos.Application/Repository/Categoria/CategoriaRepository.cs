using ApiVideos.Application.Repository.Base;

namespace ApiVideos.Application.Repository.Categoria;

public class CategoriaRepository(ApiVideosContext context) : BaseCrudRepository<CategoriaEntity>(context)
{
    
}
