
using ApiVideos.Application.Repository.Interface.Video;

namespace ApiVideos.Application.Endpoint.Categorias;

public sealed class CategoriaFiltroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}/videos", GetVideosPorCategoriaAsync)
            .Produces<List<VideoEntity>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetVideosPorCategoriaAsync(long id, IVideoRepository repository, CancellationToken cancellationToken)
    {
        var videos = await repository.GetByCategoriaIdAsync(id, cancellationToken);

        return Results.Ok(videos);
    }
}
