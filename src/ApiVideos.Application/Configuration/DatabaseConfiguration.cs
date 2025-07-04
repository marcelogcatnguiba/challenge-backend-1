using ApiVideos.Application.Context;

namespace ApiVideos.Application.Configuration;

public static class DatabaseConfiguration
{
    public static void CreateDatabase(this IServiceCollection services)
    {
        var scope = services.BuildServiceProvider().CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApiVideosContext>();

        context?.Database.EnsureCreated();
    }
}
