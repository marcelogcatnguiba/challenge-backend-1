using ApiVideos.Application.Dtos.Usuario;
using ApiVideos.Application.Entities.Usuario;
using ApiVideos.Application.Request.Usuario;
using AutoMapper;

namespace ApiVideos.Application.Mapper.Usuarios;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioEntity, UsuarioDto>().ReverseMap();
        CreateMap<UsuarioEntity, UsuarioRequest>().ReverseMap();
    }
}
