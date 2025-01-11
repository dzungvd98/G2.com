using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDetailsDTO>> GetCategoriesByTypeAsync(string typeFilter);
        Task<List<Product>> GetProductsByCategoryIdAsyc(int categoryId);
        Task<PaginatedResult<CategoryDetailsDTO>> SearchCategoriesAsync(CategorySearchDTO searchDTO);
    }
}
