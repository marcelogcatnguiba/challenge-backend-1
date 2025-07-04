namespace ApiVideos.Application.Endpoint.Videos;

public class DeleteVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/", DeleteAsync)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> DeleteAsync(long id, IRepository<VideosEntity> repository, CancellationToken cancellationToken)
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
}
