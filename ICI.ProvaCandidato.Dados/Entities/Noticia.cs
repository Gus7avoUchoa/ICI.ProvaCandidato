using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Noticia
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

        public List<NoticiaTag> NoticiasTags { get; set; } = new List<NoticiaTag>();
    }
}
