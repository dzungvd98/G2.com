using DataLayer.Database;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Like?> GetLikeByUserAndReviewAsync(int userId, int reviewId)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.UserId == userId && l.ReviewId == reviewId);
        }

        public async Task<Like> AddLikeAsync(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task DeleteLikeAsync(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }
}
