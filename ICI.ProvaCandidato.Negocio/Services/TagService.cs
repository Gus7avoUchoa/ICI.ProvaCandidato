using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Repositories;
using ICI.ProvaCandidato.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;

        public TagService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id);
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            return await _tagRepository.CreateAsync(tag);
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            return await _tagRepository.UpdateAsync(tag);
        }

        public async Task DeleteAsync(int id)
        {
            await _tagRepository.DeleteAsync(id);
        }
    }
}
