using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Entities.Usuario;

public class UsuarioEntity : BaseEntity
{
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
}
