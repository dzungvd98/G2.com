using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDetailsDTO>> GetCategoriesByTypeAsync(string typeFilter)
        {
            var query = _context.Categories
            .Include(c => c.ParentCategory) // Load parent category
            .Join(_context.ProductCategories, c => c.CategoryId, pc => pc.CategoryId, (c, pc) => new { c, pc })
            .Join(_context.Products, x => x.pc.ProductId, p => p.ProductId, (x, p) => new { x.c, p })
            .Join(_context.Types, x => x.p.TypeId, t => t.TypeId, (x, t) => new { x.c, x.p, t })
            .Where(x => typeFilter == "all" || string.IsNullOrEmpty(typeFilter) || x.t.TypeName == typeFilter)
            .GroupBy(x => new { x.c.CategoryName, ParentCategoryName = x.c.ParentCategory.CategoryName, x.t.TypeName })
            .Select(g => new CategoryDetailsDTO
            {
                CategoryName = g.Key.CategoryName,
                ParentCategoryName = g.Key.ParentCategoryName,
                TypeName = g.Key.TypeName,
                ProductCount = g.Count()
            });

            return await query.ToListAsync();
        }

        public Task<(IEnumerable<CategoryDetailsDTO> categories, int totalCount)> SearchCategoriesAsync(CategorySearchDTO queryParams)
        {
            return 
        }
    }
}
