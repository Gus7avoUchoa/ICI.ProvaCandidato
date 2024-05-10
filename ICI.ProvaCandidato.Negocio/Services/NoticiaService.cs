using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Repositories;
using ICI.ProvaCandidato.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly NoticiaRepository _noticiaRepository;

        public NoticiaService(NoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _noticiaRepository.GetAllAsync();
        }

        public async Task<Noticia> GetByIdAsync(int id)
        {
            return await _noticiaRepository.GetByIdAsync(id);
        }

        public async Task<Noticia> CreateAsync(Noticia noticia)
        {
            return await _noticiaRepository.CreateAsync(noticia);
        }

        public async Task<Noticia> UpdateAsync(Noticia noticia)
        {
            return await _noticiaRepository.UpdateAsync(noticia);
        }

        public async Task DeleteAsync(int id)
        {
            await _noticiaRepository.DeleteAsync(id);
        }
    }
}
