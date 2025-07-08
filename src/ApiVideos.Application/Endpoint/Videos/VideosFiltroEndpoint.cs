
using ApiVideos.Application.Repository.Interface.Video;
using Microsoft.AspNetCore.Mvc;

namespace ApiVideos.Application.Endpoint.Videos;

public sealed class VideosFiltroEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/titulo/", GetByTituloAsync)
            .Produces<List<VideosEntity>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetByTituloAsync([FromQuery] string? titulo, IVideoRepository repository, CancellationToken cancellationToken)
    {
        var videos = await repository.GetByTituloAsync(titulo, cancellationToken);

        return Results.Ok(videos);
    }
}
