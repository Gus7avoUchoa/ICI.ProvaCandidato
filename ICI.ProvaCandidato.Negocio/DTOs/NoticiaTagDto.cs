using ICI.ProvaCandidato.Dados.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.DTOs
{
    public class NoticiaTagDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
