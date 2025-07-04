namespace ApiVideos.Application.Endpoint.Videos;

public class CreateVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", CreateAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> CreateAsync(
        VideosEntity entity,
        IRepository<VideosEntity> repository,
        IValidator<VideosEntity> validator,
        CancellationToken cancellationToken)
    {
        try
        {
            await validator.ValidateAndThrowAsync(entity, cancellationToken);

            await repository.CreateAsync(entity, cancellationToken);

            return Results.Created("/videos/{id}", entity);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.ToDictionary(x => x.PropertyName, x => new [] { x.ErrorMessage });

            return Results.ValidationProblem(errors, type: nameof(ValidationException), title: "Ocorreu um ou mais erros de validação");
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro requisição {ex.InnerException?.Message ?? ex.Message}");
        }
    }
}
