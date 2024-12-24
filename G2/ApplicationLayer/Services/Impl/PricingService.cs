using DataLayer.DTO;
using DataLayer.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Impl
{
    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public Task<IEnumerable<PricingDTO>> GetPricingByProductId(int productId)
        {
            return _pricingRepository.GetPricesByProductId(productId);
        }
    }
}
