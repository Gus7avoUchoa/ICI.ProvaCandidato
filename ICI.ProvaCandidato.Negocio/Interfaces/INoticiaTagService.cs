using ICI.ProvaCandidato.Negocio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface INoticiaTagService
    {
        Task<IEnumerable<NoticiaTagDto>> GetAllAsync();
        Task<NoticiaTagDto> GetByIdAsync(int id);
        Task<NoticiaTagDto> CreateAsync(NoticiaTagDto noticiaTag);
        Task<NoticiaTagDto> UpdateAsync(NoticiaTagDto noticiaTag);
        Task DeleteAsync(int id);
    }
}
