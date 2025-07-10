
using ApiVideos.Application.Dtos.Videos;
using ApiVideos.Application.Endpoint.Base;
using ApiVideos.Application.Request.Videos;

namespace ApiVideos.Application.Endpoint.Videos;

public sealed class VideosCrudEndpoint : BaseCrudEndpoint<VideoEntity, VideosRequest, VideoDto>
{
    
}
