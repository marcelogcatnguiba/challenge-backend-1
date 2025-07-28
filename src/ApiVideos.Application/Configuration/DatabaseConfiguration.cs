namespace ApiVideos.Application.Configuration;

public static class DatabaseConfiguration
{
    public static void CreateDatabase(this IServiceCollection services)
    {
        var scope = services.BuildServiceProvider().CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApiVideosContext>();

        context?.Database.EnsureCreated();

        if (context?.Database.HasPendingModelChanges() ?? false)
        {
            context?.Database.Migrate();
        }
    }
}
