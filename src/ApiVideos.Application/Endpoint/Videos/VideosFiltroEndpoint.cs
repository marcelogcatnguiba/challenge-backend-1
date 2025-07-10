
using ApiVideos.Application.Repository.Interface.Video;
using Microsoft.AspNetCore.Mvc;
using ApiVideos.Application.Dtos.Videos;
using AutoMapper;

namespace ApiVideos.Application.Endpoint.Videos;

public sealed class VideosFiltroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/titulo/", GetByTituloAsync)
            .Produces<List<VideoDto>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetByTituloAsync([FromQuery] string? titulo,
        IVideoRepository repository,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        var videos = await repository.GetByTituloAsync(titulo, cancellationToken);

        var result = mapper.Map<List<VideoDto>>(videos);

        return Results.Ok(result);
    }
}
