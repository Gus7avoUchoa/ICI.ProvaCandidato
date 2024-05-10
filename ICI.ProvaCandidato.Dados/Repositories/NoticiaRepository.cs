using ICI.ProvaCandidato.Dados.Context;
using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _context.Noticias.ToListAsync();
        }

        public async Task<Noticia> GetByIdAsync(int id)
        {
            return await _context.Noticias.FindAsync(id);
        }

        public async Task<Noticia> CreateAsync(Noticia noticia)
        {
            _context.Noticias.Add(noticia);
            await _context.SaveChangesAsync();
            return noticia;
        }

        public async Task<Noticia> UpdateAsync(Noticia noticia)
        {
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
    }
}
