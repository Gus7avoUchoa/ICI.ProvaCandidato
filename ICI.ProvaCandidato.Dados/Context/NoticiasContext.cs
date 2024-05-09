using ICI.ProvaCandidato.Dados.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados.Context
{
    public class NoticiasContext : DbContext
    {
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Noticia> Noticias => Set<Noticia>();
        public DbSet<NoticiaTag> NoticiaTags => Set<NoticiaTag>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}
