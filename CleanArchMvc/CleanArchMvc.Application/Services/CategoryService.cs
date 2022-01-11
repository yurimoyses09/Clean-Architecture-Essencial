using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategotyService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO category)
        {   
            await _categoryRepository.CreateCategoryAsync(_mapper.Map<Category>(category));
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            return _mapper.Map<CategoryDTO>(_categoryRepository.GetCategoryPerIdAsync(id));
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetCategoriesAsync());
        }

        public async Task Remove(int id)
        {
            await _categoryRepository.RemoveCategoryAsync(_categoryRepository.GetCategoryPerIdAsync(id).Result);
        }

        public async Task Update(CategoryDTO category)
        {
            await _categoryRepository.UpdateCategoryAsync(_mapper.Map<Category>(category));
        }
    }
}
