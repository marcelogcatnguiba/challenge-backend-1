using ApiVideos.Application.Endpoint.Interface;
using ApiVideos.Application.Endpoint.Videos;

namespace ApiVideos.Application.Endpoint.All;

public static class Endpoints
{
    public static void MapEndpoins(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints
            .MapGroup("v1/videos")
            .WithTags("videos")
            .MapEndpoint<GetAllVideosEndpoint>()
            .MapEndpoint<GetByIdVideosEndpoint>()
            .MapEndpoint<CreateVideosEndpoint>()
            .MapEndpoint<UpdateVideosEndpoint>()
            .MapEndpoint<DeleteVideosEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
    {
        T.Map(app);
        return app;
    }
}
