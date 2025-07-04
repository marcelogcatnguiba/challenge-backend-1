using ApiVideos.Application.Endpoint.Interface;
using ApiVideos.Application.Entities;
using ApiVideos.Application.Repository.Interface.Base;

namespace ApiVideos.Application.Endpoint.Videos;

public class CreateVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", CreateAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

    }

    private static async Task<IResult> CreateAsync(VideosEntity entity, IRepository<VideosEntity> repository, CancellationToken cancellationToken)
    {
        try
        {
            await repository.CreateAsync(entity, cancellationToken);

            return Results.Created("/videos/{id}", entity);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro requisição {ex.Message}");
        }
    }
}
