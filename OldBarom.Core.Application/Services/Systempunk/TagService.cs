using AutoMapper;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Application.Interfaces.Systempunk;
using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Interfaces;

namespace OldBarom.Core.Application.Services.Systempunk
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly Mapper _mapper;
        public TagService(ITagRepository tagRepository, Mapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task Add(TagDTO tagDTO)
        {
            var tagEntity = _mapper.Map<Tag>(tagDTO);
            await _tagRepository.CreateAsync(tagEntity);
        }

        public async Task Delete(int id)
        {
            await _tagRepository.RemoveAsync(id);
        }

        public async Task<TagDTO> GetTagById(int id)
        {
            var tagEntity = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<TagDTO>(tagEntity);
        }

        public async Task<IEnumerable<TagDTO>> GetTags()
        {
            var tagsEntity = await _tagRepository.GetTagsAsync();
            return _mapper.Map<IEnumerable<TagDTO>>(tagsEntity);
        }

        public async Task Update(TagDTO tagDTO)
        {
            var tagEntity = _mapper.Map<Tag>(tagDTO);
            await _tagRepository.UpdateAsync(tagEntity);
        }
    }
}
