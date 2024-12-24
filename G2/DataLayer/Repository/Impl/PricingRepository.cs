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
    public class PricingRepository : IPricingRepository
    {
        private readonly ApplicationDbContext _context;

        public PricingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PricingDTO>> GetPricesByProductId(int productId)
        {
            var pricings = await _context.Pricings
                .Where(p => p.ProductId == productId)
                .Include(p => p.Package)
                .Select(p => new PricingDTO
                {
                    PricingId = p.PricingId,
                    Description = p.Description,
                    ContactLink = p.ContactLink,
                    IsFreeTrial = p.IsFreeTrial,
                    PricingType = p.PriceType,
                    Price = p.Price,
                    PackageName = p.Package.PackageName
                })
                .ToListAsync();
            return pricings;
        }
    }
}
