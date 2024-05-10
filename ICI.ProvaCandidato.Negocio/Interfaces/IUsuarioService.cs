
using ICI.ProvaCandidato.Negocio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync(string searchTerm = null);
        Task<UsuarioDto> GetByIdAsync(int id);
        Task<UsuarioDto> CreateAsync(UsuarioDto usuario);
        Task<UsuarioDto> UpdateAsync(UsuarioDto usuario);
        Task DeleteAsync(int id);
    }
}
