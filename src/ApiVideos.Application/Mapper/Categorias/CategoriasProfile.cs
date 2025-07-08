using ApiVideos.Application.Request.Categorias;
using ApiVideos.Application.Response.Categorias;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Categorias;

public class CategoriasProfile : Profile
{
    public CategoriasProfile()
    {
        CreateMap<CategoriaEntity, CategoriasRequest>().ReverseMap();
        CreateMap<CategoriaEntity, CategoriasResponse>().ReverseMap();
    }
}
