using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(250)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(250)]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
        public string Email { get; set; }

        public List<Noticia> Noticias { get; set; }
    }
}
