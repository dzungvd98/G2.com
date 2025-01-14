using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Task<List<ProductDTO>> GetProductsByCategoryIdAsyc(int categoryId)
        {
            var result = _context.Products
                .Join(_context.Reviews,
                    product => product.ProductId,
                    review => review.ProductId,
                    (product, review) => new { Product = product, Review = review })
                .Join(_context.ProductCategories,
                    combined => combined.Product.ProductId,
                    category => category.ProductId,
                    (combined, category) => new { combined.Product, combined.Review, Category = category })
                    .Where(item => item.Category.CategoryId == categoryId)
                    .GroupBy(item => new
                    {
                        item.Product.ProductId,
                        item.Product.ProductName,
                        item.Product.ProductLogo,
                        item.Product.Description
                    })
                    .Select(group => new ProductDTO
                    {
                        ProductId = group.Key.ProductId,
                        ProductName = group.Key.ProductName,
                        Description = group.Key.Description,
                        AveragePoint = group.Average(x => x.Review.ReviewId),
                        CountRate = group.Count()
                    })
                    .OrderByDescending(product => product.AveragePoint)
                    .Take(4)
                    .ToListAsync();
                                                                                        
            return result;
        }

        public async Task<List<CategoryDTO>> GetRelateCategoryByIdAsync(int categoryId)
        {
            var result = await _context.Categories
                .Join(_context.ProductCategories,
                    category => category.CategoryId,
                    pc => pc.CategoryId,
                    (category, pc) => new { Category = category, ProductCategory = pc })
                .Where(combined => combined.Category.ParentCategoryID == categoryId)
                .GroupBy(item => new
                {
                    item.Category.CategoryId,
                    item.Category.CategoryName
                })
                .Select(group => new CategoryDTO
                {
                    CategoryID = group.Key.CategoryId,
                    CategoryName = group.Key.CategoryName,
                    CountProduct = group.Count()
                })
                .OrderByDescending(item => item.CountProduct)
                .Take(8)
                .ToListAsync();
            return result;
        }

        public Task<(IEnumerable<CategoryDetailsDTO> categories, int totalCount)> SearchCategoriesAsync(CategorySearchDTO queryParams)
        {
            return null;
        }

        Task<PaginatedResult<CategoryDetailsDTO>> ICategoryRepository.SearchCategoriesAsync(CategorySearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
