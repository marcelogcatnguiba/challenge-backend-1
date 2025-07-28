using ApiVideos.Application.Entities.Usuario;

namespace ApiVideos.Application.Validation.Usuarios;

public class UsuarioValidator : AbstractValidator<UsuarioEntity>
{
    public UsuarioValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(x => $"{nameof(x.Email)} obrigatorio.");
        RuleFor(x => x.Senha).NotEmpty().WithMessage(x => $"{nameof(x.Senha)} obrigatorio.");
    }
}
