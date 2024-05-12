using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.DTOs
{
    public class NoticiaDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(250)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "text")]
        public string Texto { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<TagDto> NoticiasTags { get; set; }

        [Required(ErrorMessage = "O campo Tags é obrigatório.")]
        public List<int> TagIds { get; set; }
    }
}
