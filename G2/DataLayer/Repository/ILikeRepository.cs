using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface ILikeRepository
    {
        Task<Like?> GetLikeByUserAndReviewAsync(int userId, int reviewId);
        Task<Like> AddLikeAsync(Like like);
        Task DeleteLikeAsync(Like like);

    }
}
