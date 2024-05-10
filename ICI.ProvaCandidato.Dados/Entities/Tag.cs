using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public List<NoticiaTag> NoticiasTags { get; set; }
    }
}
