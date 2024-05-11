using System.Collections.Generic;

namespace ICI.ProvaCandidato.Negocio.DTOs
{
    public class NoticiaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Usuario { get; set; }
        public int UsuarioId { get; set; }
        public List<TagDto> NoticiasTags { get; set; }
    }
}
