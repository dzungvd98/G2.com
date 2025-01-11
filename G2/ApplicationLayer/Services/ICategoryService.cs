using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDetailsDTO>> GetCategoriesByTypeAsync(string typeFilter);
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<PaginatedResult<CategoryDetailsDTO>> SearchCategoriesAsync(CategorySearchDTO searchDTO);
    }
}
