using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Senha { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Email { get; set; }
    }
}
