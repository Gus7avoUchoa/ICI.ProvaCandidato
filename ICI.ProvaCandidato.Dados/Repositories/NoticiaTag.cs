using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    internal class NoticiaTag
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NoticiaId")]
        public int NoticiaId { get; set; }

        [ForeignKey("TagId")]
        public int TagId { get; set; }
    }
}
