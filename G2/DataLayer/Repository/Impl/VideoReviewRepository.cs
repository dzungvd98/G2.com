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
    public class VideoReviewRepository : IVideoReviewRepository
    {
        public readonly ApplicationDbContext _context;

        public VideoReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VideoReviewDTO>> GetVideoReviewByProductIdAsync(int productId)
        {
            var videoReviewList = await _context.Reviews
                .Join(_context.ReviewVideos, r => r.ReviewId, rv => rv.ReviewId, (r, rv) => new { Reviews = r, ReviewVideos = rv })
                .Join(_context.Users, combined => combined.Reviews.UserId, u => u.UserId, (combined, u) => new { combined.Reviews, combined.ReviewVideos, u })
                .Where(combined => combined.Reviews.ProductId == productId)
                .Select(combined => new VideoReviewDTO
                {
                    Avatar = combined.u.Avatar,
                    Content = combined.Reviews.Content,
                    Rate = combined.Reviews.Rate,
                    Username = combined.u.UserName,
                    VideoRef = combined.ReviewVideos.VideoRef
                }).ToListAsync();
            return videoReviewList;
        }
    }
}