using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Titulo { get; set; }

        public string Texto { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}
