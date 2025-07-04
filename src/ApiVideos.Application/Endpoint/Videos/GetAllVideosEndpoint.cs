namespace ApiVideos.Application.Endpoint.Videos;

public class GetAllVideosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllAsync)
            .Produces<List<VideosEntity>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetAllAsync(IRepository<VideosEntity> context, CancellationToken cancellationToken)
    {
        return Results.Ok(await context.GetAsync(cancellationToken));
    }
}
