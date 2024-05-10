using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados.Context
{
    public class NoticiasContext : DbContext
    {
        public NoticiasContext(DbContextOptions<NoticiasContext> options) : base(options) { }

        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Noticia> Noticias => Set<Noticia>();
        public DbSet<NoticiaTag> NoticiaTags => Set<NoticiaTag>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}
