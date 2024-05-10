using System.Collections.Generic;
using System.Threading.Tasks;
using ICI.ProvaCandidato.Dados.Entities;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface INoticiaService
    {
        Task<IEnumerable<Noticia>> GetAllAsync();
        Task<Noticia> GetByIdAsync(int id);
        Task<Noticia> CreateAsync(Noticia noticia);
        Task<Noticia> UpdateAsync(Noticia noticia);
        Task DeleteAsync(int id);
    }
}
