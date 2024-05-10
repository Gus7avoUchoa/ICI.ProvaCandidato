using ICI.ProvaCandidato.Negocio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> GetAllAsync(string searchTerm = null);
        Task<TagDto> GetByIdAsync(int id);
        Task<TagDto> CreateAsync(TagDto tag);
        Task<TagDto> UpdateAsync(TagDto tag);
        Task DeleteAsync(int id);
    }
}
