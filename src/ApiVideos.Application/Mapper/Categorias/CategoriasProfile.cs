using ApiVideos.Application.Dtos.Categorias;
using ApiVideos.Application.Request.Categorias;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Categorias;

public class CategoriasProfile : Profile
{
    public CategoriasProfile()
    {
        CreateMap<CategoriaEntity, CategoriasRequest>().ReverseMap();
        CreateMap<CategoriaEntity, CategoriaDto>().ReverseMap();
    }
}
