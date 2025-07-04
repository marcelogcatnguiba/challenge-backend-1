namespace ApiVideos.Application.Validation.Videos;

public class VideosValidation : AbstractValidator<VideosEntity>
{
    public VideosValidation()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Titulo)} obrigatorio.");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Descricao)} obrigatorio.");

        RuleFor(x => x.Url)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Url)} obrigatorio.");
    }
}
