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
                //.ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario.Nome))
                //.ForMember(TagDto => TagDto.NoticiasTags, opt => opt.MapFrom(src => src.NoticiasTags.Select(t => t.Tag)));
            CreateMap<Usuario, UsuarioDto>();

            // Mapeamento de DTOs para entidades
            CreateMap<TagDto, Tag>();
            CreateMap<NoticiaDto, Noticia>();
            //CreateMap<NoticiaTagDto, NoticiaTag>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
