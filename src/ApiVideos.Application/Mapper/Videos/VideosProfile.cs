using ApiVideos.Application.Dtos.Videos;
using ApiVideos.Application.Request.Videos;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Videos;

public class VideosProfile : Profile
{
    public VideosProfile()
    {
        CreateMap<VideoEntity, VideosRequest>().ReverseMap();
        CreateMap<VideoEntity, VideoDto>().ReverseMap();
    }
}
