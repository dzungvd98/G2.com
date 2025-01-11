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
                UserId = reviewDTO.UserID,
                ProductId = reviewDTO.ProductID,
                Content = reviewDTO.Content,
                Rate = reviewDTO.Rate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ReviewProsCons = reviewDTO.ProsConsIDs.Select(id => new ReviewProsCons
                {
                    ProsConsId = id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList(),
                ReviewVideos = reviewDTO.VideoRefs.Select(videoRef => new ReviewVideo
                {
                    UserId = reviewDTO.UserID,
                    VideoRef = videoRef,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList()
            };

            var addedReview = await _reviewRepository.AddReviewAsync(review);

            // Thêm ReviewDetails
            if (reviewDTO.ReviewDetails != null && reviewDTO.ReviewDetails.Any())
            {
                var reviewDetails = reviewDTO.ReviewDetails.Select(detail => new ReviewDetail
                {
                    ReviewId = addedReview.ReviewId, // Sử dụng ReviewId từ review đã được thêm
                    CriteriaId = detail.CriteriaId,
                    Rate = detail.Rate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList();

                // Gọi repository hoặc DbContext để thêm danh sách ReviewDetails
                await _reviewRepository.AddReviewDetailsAsync(reviewDetails);
            }

            return addedReview;
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID)
        { 
            return await _reviewRepository.GetReviewDetailByProductID(productID);
        }
        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            // Kiểm tra xem review có tồn tại không
            var existingReview = await _reviewRepository.GetReviewByIdAsync(reviewId);
            if (existingReview == null)
            {
                return false; // Không tồn tại
            }

            // Gọi repository để xóa
            await _reviewRepository.DeleteReviewAsync(existingReview);
            return true;
        }
    }
}
