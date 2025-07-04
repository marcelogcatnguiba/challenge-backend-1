using ApiVideos.Application.Endpoint.Interface;
using ApiVideos.Application.Entities;
using ApiVideos.Application.Repository.Interface.Base;

namespace ApiVideos.Application.Endpoint.Videos;

public class GetByIdVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", GetByIdAsync)
            .Produces<VideosEntity>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetByIdAsync(long id, IRepository<VideosEntity> context, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await context.GetByIdAsync(id, cancellationToken);

            return Results.Ok(entity);
        }
        catch (ArgumentException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }
}
