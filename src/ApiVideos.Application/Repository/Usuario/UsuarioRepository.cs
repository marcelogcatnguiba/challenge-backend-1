using ApiVideos.Application.Entities.Usuario;
using ApiVideos.Application.Repository.Base;

namespace ApiVideos.Application.Repository.Usuario;

public class UsuarioRepository(ApiVideosContext context) : BaseCrudRepository<UsuarioEntity>(context)
{
    
}
