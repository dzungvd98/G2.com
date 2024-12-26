using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IPricingService
    {
        Task<IEnumerable<PricingDTO>> GetPricingByProductIdAsync(int productId);
    }
}
