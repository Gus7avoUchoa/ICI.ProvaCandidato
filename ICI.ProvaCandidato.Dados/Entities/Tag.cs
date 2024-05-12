using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100)]
        public string Descricao { get; set; }

        public List<NoticiaTag> NoticiasTags { get; set; } = new List<NoticiaTag>();
    }
}
