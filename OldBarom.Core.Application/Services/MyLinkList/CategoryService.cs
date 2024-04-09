using AutoMapper;
using MediatR;
using OldBarom.Core.Application.DTOs.MyLinkList;
using OldBarom.Core.Application.Interfaces.MyLinkList;
using OldBarom.Core.Domain.Entities.LinkList;
using OldBarom.Core.Domain.Repository.MySkinList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Services.MyLinkList
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Categories>(category);
            await _categoryRepository.Create(categoryEntity);
            category.Id = categoryEntity.Id;
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetCategoryByID(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            await _categoryRepository.Delete(category.Id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var category = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async Task<CategoryDTO> GetCategoryByID(int id)
        {
            var category = await _categoryRepository.GetCategoryByID(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Update(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Categories>(category);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
