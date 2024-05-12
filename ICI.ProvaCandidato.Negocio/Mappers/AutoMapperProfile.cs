using AutoMapper;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.DTOs;
using System.Linq;

namespace ICI.ProvaCandidato.Negocio.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento de entidades para DTOs
            CreateMap<Tag, TagDto>();
            CreateMap<Noticia, NoticiaDto>();
            CreateMap<NoticiaTag, NoticiaTagDto>();
            CreateMap<Usuario, UsuarioDto>();

            // Mapeamento de DTOs para entidades
            CreateMap<TagDto, Tag>();
            CreateMap<NoticiaDto, Noticia>();
            CreateMap<NoticiaTagDto, NoticiaTag>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<NoticiaTag, TagDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Tag.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Tag.Descricao));
        }
    }
}
