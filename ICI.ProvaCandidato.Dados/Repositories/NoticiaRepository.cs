using ICI.ProvaCandidato.Dados.Context;
using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class NoticiaRepository
    {
        private readonly NoticiasContext _context;

        public NoticiaRepository(NoticiasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _context.Noticias.Include(n => n.NoticiasTags).ThenInclude(nt => nt.Tag).ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Noticia> GetByIdAsync(int id)
        {
            return await _context.Noticias.Include(n => n.NoticiasTags).ThenInclude(nt => nt.Tag).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Noticia> CreateAsync(Noticia noticia, List<int> tagIds)
        {
            _context.Noticias.Add(noticia);
            await _context.SaveChangesAsync();
            

            foreach (var tag in tagIds)
            {
                var noticiaTag = new NoticiaTag { NoticiaId = noticia.Id, TagId = tag };
                _context.NoticiaTags.Add(noticiaTag);
            }

            await _context.SaveChangesAsync();

            return noticia;
        }

        public async Task<Noticia> UpdateAsync(Noticia noticiaAtual, List<int> tagIds)
        {
            var noticia = _context.Noticias.Include(n => n.NoticiasTags).ThenInclude(nt => nt.Tag).FirstOrDefault(n => n.Id == noticiaAtual.Id);

            if (noticia == null) throw new Exception("Notícia não encontrada.");

            noticia.Titulo = noticiaAtual.Titulo;
            noticia.Texto = noticiaAtual.Texto;
            noticia.UsuarioId = noticiaAtual.UsuarioId;

            var tagsToRemove = noticia.NoticiasTags.Where(nt => !tagIds.Contains(nt.TagId)).ToList();
            foreach (var tag in tagsToRemove)
            {
                _context.NoticiaTags.Remove(tag);
            }

            var tagsAtuais = noticia.NoticiasTags.Select(nt => nt.TagId).ToList();
            var tagsToUpdate = tagIds.Except(tagsAtuais).ToList();
            foreach (var tag in tagsToUpdate)
            {
                var noticiaTag = new NoticiaTag { NoticiaId = noticiaAtual.Id, TagId = tag };
                _context.NoticiaTags.Add(noticiaTag);
            }

            _context.Entry(noticia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return noticia;
        }

        public async Task DeleteAsync(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id) ?? throw new Exception("Notícia não encontrada");
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsTagInUse(int tagId)
        {
            return await _context.NoticiaTags.AnyAsync(nt => nt.TagId == tagId);
        }
    }
}
