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
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Like> AddLikeAsync(AddLikeDTO addLikeDTO)
        {
            var existingLike = await _likeRepository.GetLikeByUserAndReviewAsync(addLikeDTO.UserId, addLikeDTO.ReviewId);
            if (existingLike != null)
            {
                throw new InvalidOperationException("User has already liked this review.");
            }

            var like = new Like
            {
                UserId = addLikeDTO.UserId,
                ReviewId = addLikeDTO.ReviewId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _likeRepository.AddLikeAsync(like);
        }
    }
}
