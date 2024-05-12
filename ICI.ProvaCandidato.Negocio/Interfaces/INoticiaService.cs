using ICI.ProvaCandidato.Negocio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface INoticiaService
    {
        Task<IEnumerable<NoticiaDto>> GetAllAsync(string searchTerm = null);
        Task<IEnumerable<TagDto>> GetAllTagsAsync();
        Task<NoticiaDto> GetByIdAsync(int id);
        Task<NoticiaDto> CreateAsync(NoticiaDto noticia);
        Task<NoticiaDto> UpdateAsync(NoticiaDto noticia);
        Task DeleteAsync(int id);
        Task<bool> UserExists(int id);
    }
}
