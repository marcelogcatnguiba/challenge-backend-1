using ApiVideos.Application.Request.Videos;
using ApiVideos.Application.Response.Videos;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Videos;

public class VideosProfile : Profile
{
    public VideosProfile()
    {
        CreateMap<VideoEntity, VideosRequest>().ReverseMap();
        CreateMap<VideoEntity, VideosResponse>().ReverseMap();
    }
}
