namespace ApiVideos.Application.Endpoint.Interface;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
