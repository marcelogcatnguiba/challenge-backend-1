using ApiVideos.Application.Request.Videos;
using ApiVideos.Application.Response.Videos;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Videos;

public class VideosProfile : Profile
{
    public VideosProfile()
    {
        CreateMap<VideosEntity, VideosRequest>().ReverseMap();
        CreateMap<VideosEntity, VideosResponse>().ReverseMap();
    }
}
