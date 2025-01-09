using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTO;
using DataLayer.Models;

namespace ApplicationLayer.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID);
        Task<Review> AddReviewAsync(AddReviewDTO reviewDTO);
    }
}
