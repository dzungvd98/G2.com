using DataLayer.DTO;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Impl
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> AddReviewAsync(AddReviewDTO reviewDTO)
        {
            var review = new Review
            {
                UserID = reviewDTO.UserID,
                ProductID = reviewDTO.ProductID,
                Content = reviewDTO.Content,
                Rate = reviewDTO.Rate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ReviewProsCons = reviewDTO.ProsConsIDs.Select(id => new ReviewProsCons
                {
                    ProsConsID = id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList(),
                ReviewVideos = reviewDTO.VideoRefs.Select(videoRef => new ReviewVideo
                {
                    VideoRef = videoRef,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList()
            };

            return await _reviewRepository.AddReviewAsync(review);
        }


        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID)
        { 
            return await _reviewRepository.GetReviewDetailByProductID(productID);
        }
    }
}
