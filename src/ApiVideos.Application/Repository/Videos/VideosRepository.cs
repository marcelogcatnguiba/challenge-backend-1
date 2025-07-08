using ApiVideos.Application.Repository.Base;

namespace ApiVideos.Application.Repository.Videos;

public class VideosRepository(ApiVideosContext context) : BaseCrudRepository<VideosEntity>(context)
{

}
