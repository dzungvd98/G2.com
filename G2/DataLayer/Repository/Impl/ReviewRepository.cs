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
        public ReviewRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID)
        {
            var review = await _context.Reviews
            .Where(p => p.ProductId == productID)
            .Select(p => new ReviewDTO
            {

            })
            .ToListAsync();
            return review;
        }
    }
}
