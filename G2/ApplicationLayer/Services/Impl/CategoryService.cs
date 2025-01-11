using DataLayer.DTO;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDetailsDTO>> GetCategoriesByTypeAsync(string typeFilter)
        {
            return await _categoryRepository.GetCategoriesByTypeAsync(typeFilter);
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _categoryRepository.GetProductsByCategoryIdAsyc(categoryId);
        }

        public async Task<List<CategoryDTO>> GetRelateCategoriesByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetRelateCategoryByIdAsync(categoryId);
        }
    }
}
