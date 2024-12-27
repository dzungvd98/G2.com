using DataLayer.DTO;
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

        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID)
        { 
            return await _reviewRepository.GetReviewByProductID(productID);
        }
    }
}
