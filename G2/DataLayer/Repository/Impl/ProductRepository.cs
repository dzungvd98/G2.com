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

        public async Task<IEnumerable<AlternativeProductDTO>> GetAlternativeProductByIdAsync(int productId)
        {


            var matchingProducts = _context.ProductFeatures
                .Where(pf => pf.ProductId == productId)
                .Select(pf => pf.FeatureId)
                .ToList(); // Lấy danh sách FeatureId của sản phẩm hiện tại

            var alternativeProducts = _context.ProductFeatures
                .Where(pf => pf.ProductId != productId && matchingProducts.Contains(pf.FeatureId))
                .GroupBy(pf => pf.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    MatchingFeatures = g.Count(),
                    CountReview = _context.Reviews.Count(r => r.ProductId == g.Key),
                    AvgReviewPoint = _context.Reviews
                        .Where(r => r.ProductId == g.Key)
                        .Select(r => (double?)r.Rate)
                        .Average() ?? 0.0
                });

            var results = await alternativeProducts
                .Join(_context.Products,
                    ap => ap.ProductId,
                    p => p.ProductId,
                    (ap, p) => new AlternativeProductDTO
                    {
                        ProductId = p.ProductId,
                        AveragePoint = ap.AvgReviewPoint,
                        CountRate = ap.CountReview,
                        Description = p.Description,
                        ProductName = p.ProductName,
                        Logo = p.ProductLogo
                    })

                .OrderByDescending(x => x.CountRate) // Sau đó theo số lượng đánh giá
                .Take(2) // Lấy 2 sản phẩm đầu tiên
                .ToListAsync();




            return results;
        }
    }
}
