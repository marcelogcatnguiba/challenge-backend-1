using ApiVideos.Application.Entities.Base;

namespace ApiVideos.Application.Endpoint.Base;

public abstract class BaseCrudEndpoint<T> : IEndpoint, ICrudEndpoint<T> where T : BaseEntity
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAsync)
            .Produces<List<T>>(StatusCodes.Status200OK);

        app.MapGet("/{id}", GetByIdAsync)
            .Produces<T>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/", CreateAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest);

        app.MapPut("/", UpdateAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        app.MapDelete("/", DeleteAsync)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);
    }

    public static async Task<IResult> CreateAsync(T entity, IRepository<T> repository, IValidator<T> validator, CancellationToken cancellationToken)
    {
        try
        {
            await validator.ValidateAndThrowAsync(entity, cancellationToken);

            await repository.CreateAsync(entity, cancellationToken);

            return Results.Created();
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.ToDictionary(x => x.PropertyName, x => new[] { x.ErrorMessage });

            return Results.ValidationProblem(errors, type: nameof(ValidationException), title: "Ocorreu um ou mais erros de validação");
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro requisição {ex.InnerException?.Message ?? ex.Message}");
        }
    }

    public async static Task<IResult> DeleteAsync(long id, IRepository<T> repository, CancellationToken cancellationToken)
    {
        try
        {
            await repository.DeleteAsync(id, cancellationToken);

            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro na requisição: {ex.Message ?? string.Empty}");
        }
    }

    public async static Task<IResult> GetAsync(IRepository<T> repository, CancellationToken cancellationToken)
    {
        return Results.Ok(await repository.GetAsync(cancellationToken));
    }

    public async static Task<IResult> GetByIdAsync(long id, IRepository<T> repository, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);

            return Results.Ok(entity);
        }
        catch (ArgumentException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }

    public static async Task<IResult> UpdateAsync(T entity, IRepository<T> repository, CancellationToken cancellationToken)
    {
        try
        {
            await repository.UpdateAsync(entity, cancellationToken);

            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro na requisição: {ex.Message ?? string.Empty}");
        }
    }
}
