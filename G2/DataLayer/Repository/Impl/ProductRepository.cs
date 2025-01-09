﻿using DataLayer.Database;
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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductDetailsDTO> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                .Where(p => p.ProductId == productId)
                .Select(p => new ProductDetailsDTO
                {
                    ProductName = p.ProductName,
                    Description = p.Description,
                    ProductLogo = p.ProductLogo,
                    CoverImage = p.CoverImage,
                    ProductLink = p.ProductLink,
                    AvgRate = p.Reviews.Average(r => r.Rate),
                    TotalReviews = p.Reviews.Count(),
                    TotalDiscussion = p.Discussions.Count()

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAlternativeProductByIdAsync(int productId)
        {
            var targetFeatures = _context.ProductFeatures
                .Where(p => p.ProductId == productId)
                .Select(p => p.FeatureId);

            var result = await _context.ProductFeatures
                .Where(pf => pf.ProductId != 1 && targetFeatures.Contains(pf.FeatureId))
                .GroupBy(pf => pf.ProductId)
                .Select(group => new
                {
                    ProductId = group.Key,
                    NumberFeature = group.Count()
                })
                .OrderByDescending(p => p.NumberFeature)
                .Join(_context.Products,
                    group => group.ProductId,
                    product => product.ProductId,
                    (group, product) => new Product
                    {
                        ProductName = product.ProductName,
                        ProductId = product.ProductId,
                        CoverImage = product.CoverImage,
                        Description = product.Description,  
                        ProductLink = product.ProductLink,  
                        ProductLogo = product.ProductLogo,
                        Type = product.Type,
                    }).ToListAsync();

            return result;
        }
    }
}
