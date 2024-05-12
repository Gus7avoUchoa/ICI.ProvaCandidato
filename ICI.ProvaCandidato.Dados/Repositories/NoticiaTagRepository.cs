using ICI.ProvaCandidato.Dados.Context;
using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class NoticiaTagRepository
    {
        private readonly NoticiasContext _context;

        public NoticiaTagRepository(NoticiasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NoticiaTag>> GetAllAsnc()
        {
            return await _context.NoticiaTags.ToListAsync();
        }

        public async Task<NoticiaTag> GetByIdAsync(int id)
        {
            return await _context.NoticiaTags.FindAsync(id);
        }

        public async Task<NoticiaTag> CreateAsync(NoticiaTag noticiaTag)
        {
            _context.NoticiaTags.Add(noticiaTag);
            await _context.SaveChangesAsync();
            return noticiaTag;
        }

        public async Task<NoticiaTag> UpdateAsync(NoticiaTag noticiaTag)
        {
            _context.Entry(noticiaTag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return noticiaTag;
        }

        public async Task DeleteAsync(int id)
        {
            var noticiaTag = await _context.NoticiaTags.FindAsync(id) ?? throw new Exception("NotíciaTag não encontrada");
            _context.NoticiaTags.Remove(noticiaTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByNoticiaAsync(int noticiaId)
        {
            var noticiaTags = await _context.NoticiaTags.Where(nt => nt.NoticiaId == noticiaId).ToListAsync();
            _context.NoticiaTags.RemoveRange(noticiaTags);
            await _context.SaveChangesAsync();
        }
    }
}
