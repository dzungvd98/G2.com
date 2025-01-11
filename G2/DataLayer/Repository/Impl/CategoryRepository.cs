﻿using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Product>> GetProductsByCategoryIdAsyc(int categoryId)
        {
            var products = _context.ProductCategories
                .Join(_context.Products, pc => pc.ProductId, p => p.ProductId, (pc, p) => new { pc, p })
                .Where(combined => combined.pc.CategoryId == categoryId)
                .Select(g => new Product
                {
                    ProductName = g.p.ProductName,
                    CoverImage = g.p.CoverImage,
                    Description = g.p.Description,
                    ProductLink = g.p.ProductLink,
                    ProductLogo = g.p.ProductLogo
                }).ToListAsync();
            return products;
        }

        public async Task<PaginatedResult<CategoryDetailsDTO>> SearchCategoriesAsync(CategorySearchDTO searchDTO)
        {
            var query = _context.Categories
                .Include(c => c.ParentCategory)
                .Join(_context.ProductCategories, c => c.CategoryId, pc => pc.CategoryId, (c, pc) => new { c, pc })
                .Join(_context.Products, x => x.pc.ProductId, p => p.ProductId, (x, p) => new { x.c, p })
                .Join(_context.Types, x => x.p.TypeId, t => t.TypeId, (x, t) => new { x.c, x.p, t })
                .Where(x => searchDTO.Type == "all" || string.IsNullOrEmpty(searchDTO.Type) || x.t.TypeName == searchDTO.Type)
                .Where(x => string.IsNullOrEmpty(searchDTO.Keyword) || x.c.CategoryName.Contains(searchDTO.Keyword))
                .GroupBy(x => new { x.c.CategoryName, ParentCategoryName = x.c.ParentCategory.CategoryName, x.t.TypeName })
                .Select(g => new CategoryDetailsDTO
                {
                    CategoryName = g.Key.CategoryName,
                    ParentCategoryName = g.Key.ParentCategoryName,
                    TypeName = g.Key.TypeName,
                    ProductCount = g.Count()
                });

            if (!string.IsNullOrEmpty(searchDTO.SortBy))
            {
                query = searchDTO.IsAscending ? query.OrderBy(x => EF.Property<object>(x, searchDTO.SortBy)) : query.OrderByDescending(x => EF.Property<object>(x, searchDTO.SortBy));
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((searchDTO.PageNumber - 1) * searchDTO.PageSize).Take(searchDTO.PageSize).ToListAsync();

            return new PaginatedResult<CategoryDetailsDTO>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = searchDTO.PageNumber,
                PageSize = searchDTO.PageSize
            };
        }
    }
}
