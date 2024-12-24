using DataLayer.Database;
using DataLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class ProductFeatureRepository : IProductFeatureRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductFeatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FeatureDTO>> GetFeaturesByProductIdAsync(int productId)
        {
            var features = await _context.ProductFeatures
                .Where(pf => pf.ProductId == productId) // Lọc theo ProductID
                .Select(pf => new FeatureDTO
                {
                    FeatureId = pf.Feature.FeatureId,
                    FeatureName = pf.Feature.FeatureName,
                    ParentFeatureName = pf.Feature.ParentFeature != null
                                ? pf.Feature.ParentFeature.FeatureName
                                : null
                })
                .ToListAsync();
            return features; 
        }
    }
}
