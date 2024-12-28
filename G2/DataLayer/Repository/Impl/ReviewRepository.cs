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
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID)
        {
            var topReviews =await _context.Reviews
                .Join(_context.Users,
                    r => r.UserId,
                    u => u.UserId,
                    (r, u) => new { r, u })
                .Join(_context.Companies,
                    ru => ru.u.CompanyId,
                    c => c.CompanyId,
                    (ru, c) => new { ru.r, ru.u, c })
                .Join(_context.CompanySizes,
                    ruc => ruc.c.CompanySizeId,
                    cs => cs.CompanySizeId,
                    (ruc, cs) => new
                    {
                        ruc.r,
                        ruc.u,
                        CompanySizeName = cs.CompanySizeName
                    })
                .Where(x => x.r.ProductId == 1)
                .OrderByDescending(x => x.r.CreatedAt)
                .Take(2)
                .Select(x => new ReviewDTO
                {
                    UserName = x.u.UserName,
                    Rate = x.r.Rate,
                    Content = x.r.Content,
                    CompanySizeName = x.CompanySizeName
                })
                .ToListAsync();
            return topReviews;

        }
    }
}
