using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface  IReviewRepository
    {
        Task<IEnumerable<ReviewDTO>> GetReviewDetailByProductID(int productID);
        Task<Review> AddReviewAsync(Review review);
        Task AddReviewDetailsAsync(IEnumerable<ReviewDetail> reviewDetails);
        Task DeleteReviewAsync(Review review);
        Task<Review?> GetReviewByIdAsync(int reviewId);
    }
}
