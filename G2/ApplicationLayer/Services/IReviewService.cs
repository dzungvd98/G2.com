using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTO;

namespace ApplicationLayer.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetReviewByProductID(int productID);
    }
}
