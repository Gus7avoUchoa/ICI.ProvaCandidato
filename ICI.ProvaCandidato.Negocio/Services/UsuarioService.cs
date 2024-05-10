using AutoMapper;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Repositories;
using ICI.ProvaCandidato.Negocio.DTOs;
using ICI.ProvaCandidato.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(UsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync(string searchTerm = null)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                usuarios = usuarios.Where(u => u.Nome.ToLower().Contains(searchTerm.ToLower()));
            }
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario is null) return null;
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto)
        {
            // Desacoplar ICI.ProvaCandidato.Dados.Entities;
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var createdUsuario = await _usuarioRepository.CreateAsync(usuario);
            return _mapper.Map<UsuarioDto>(createdUsuario);
        }

        public async Task<UsuarioDto> UpdateAsync(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioDto>(updatedUsuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
