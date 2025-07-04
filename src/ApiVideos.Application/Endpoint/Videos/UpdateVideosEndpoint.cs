namespace ApiVideos.Application.Endpoint.Videos;

public class UpdateVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/", UpdateAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> UpdateAsync(
        VideosEntity videosEntity,
        IRepository<VideosEntity> repository,
        CancellationToken cancellationToken)
    {
        try
        {
            await repository.UpdateAsync(videosEntity, cancellationToken);

            return Results.Ok(videosEntity);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Erro na requisição: {ex.Message ?? string.Empty}");
        }
    }
}
