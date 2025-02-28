﻿using AutoMapper;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Repositories;
using ICI.ProvaCandidato.Negocio.DTOs;
using ICI.ProvaCandidato.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly NoticiaRepository _noticiaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public NoticiaService(NoticiaRepository noticiaRepository, UsuarioRepository usuarioRepository, IMapper mapper)
        {
            _noticiaRepository = noticiaRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoticiaDto>> GetAllAsync(string searchTerm = null)
        {
            var noticias = await _noticiaRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                noticias = noticias.Where(n => n.Titulo.ToLower().Contains(searchTerm.ToLower()));
            }
            return _mapper.Map<IEnumerable<NoticiaDto>>(noticias);
        }

        public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
        {
            var tags = await _noticiaRepository.GetAllTagsAsync();
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<NoticiaDto> GetByIdAsync(int id)
        {
            var noticias = await _noticiaRepository.GetByIdAsync(id);
            if (noticias is null) return null;
            return _mapper.Map<NoticiaDto>(noticias);
        }

        public async Task<NoticiaDto> CreateAsync(NoticiaDto noticiaDto)
        {
            var noticia = _mapper.Map<Noticia>(noticiaDto);
            var createdNoticia = await _noticiaRepository.CreateAsync(noticia, noticiaDto.TagIds);
            return _mapper.Map<NoticiaDto>(createdNoticia);
        }

        public async Task<NoticiaDto> UpdateAsync(NoticiaDto noticiaDto)
        {
            var noticia = _mapper.Map<Noticia>(noticiaDto);
            var updatedNoticia = await _noticiaRepository.UpdateAsync(noticia, noticiaDto.TagIds);
            return _mapper.Map<NoticiaDto>(updatedNoticia);
        }

        public async Task DeleteAsync(int id)
        {
            await _noticiaRepository.DeleteAsync(id);
        }

        public async Task<bool> UserExists(int id)
        {
            return await _usuarioRepository.UserExists(id);
        }
    }
}
