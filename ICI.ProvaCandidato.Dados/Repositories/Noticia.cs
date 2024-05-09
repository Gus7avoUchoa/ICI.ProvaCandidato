using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Texto { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<NoticiaTag> NoticiasTags { get; set; }
    }
}
