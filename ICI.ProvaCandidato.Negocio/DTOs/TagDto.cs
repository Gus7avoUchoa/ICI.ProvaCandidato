using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.DTOs
{
    public class TagDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100)]
        public string Descricao { get; set; }
        public List<NoticiaTagDto> NoticiasTags { get; set; }
    }
}
