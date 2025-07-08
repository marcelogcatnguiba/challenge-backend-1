using ApiVideos.Application.Endpoint.Categorias;

namespace ApiVideos.Application.Endpoint.All;

public static class Endpoints
{
    public static void MapEndpoins(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints
            .MapGroup("v1/videos")
            .WithTags("videos")
            .MapEndpoint<VideosCrudEndpoint>()
            .MapEndpoint<VideosFiltroEndpoint>();

        endpoints
            .MapGroup("v1/categorias")
            .WithTags("categorias")
            .MapEndpoint<CategoriaCrudEndpoint>()
            .MapEndpoint<CategoriaFiltroEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
    {
        T.Map(app);
        return app;
    }
}
