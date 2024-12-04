using DataLayer.Database;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.ProductRepository
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
            return await _context.products
                                  .Include(p => p.CompanyId) // Nếu cần lấy thông tin công ty
                                  .Include(p => p.CategoryId) // Nếu cần lấy thông tin danh mục
                                  .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.products
                                  .Include(p => p.CompanyId)
                                  .Include(p => p.CategoryId)
                                  .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddProductAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
