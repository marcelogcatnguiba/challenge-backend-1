using ApiVideos.Application.Dtos.Videos;
using ApiVideos.Application.Repository.Interface.Video;
using AutoMapper;

namespace ApiVideos.Application.Endpoint.Categorias;

public sealed class CategoriaFiltroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}/videos", GetVideosPorCategoriaAsync)
            .Produces<List<VideoDto>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetVideosPorCategoriaAsync(long id,
        IVideoRepository repository,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        var videos = await repository.GetByCategoriaIdAsync(id, cancellationToken);

        var result = mapper.Map<List<VideoDto>>(videos);

        return Results.Ok(result);
    }
}
