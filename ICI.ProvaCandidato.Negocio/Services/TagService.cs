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
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(TagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> GetAllAsync(string searchTerm = null)
        {
            var tags = await _tagRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                tags = tags.Where(t => t.Descricao.ToLower().Contains(searchTerm.ToLower()));
            }
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var tags = await _tagRepository.GetByIdAsync(id);
            if (tags is null) return null;
            return _mapper.Map<TagDto>(tags);
        }

        public async Task<TagDto> CreateAsync(TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            var createdTag = await _tagRepository.CreateAsync(tag);
            return _mapper.Map<TagDto>(createdTag);
        }

        public async Task<TagDto> UpdateAsync(TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            var updatedTag = await _tagRepository.UpdateAsync(tag);
            return _mapper.Map<TagDto>(updatedTag);
        }

        public async Task DeleteAsync(int id)
        {
            await _tagRepository.DeleteAsync(id);
        }
    }
}
