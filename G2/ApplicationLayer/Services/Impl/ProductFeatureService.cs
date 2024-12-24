using DataLayer.DTO;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Impl
{
    public class ProductFeatureService : IProductFeatureService
    {
        private readonly IProductFeatureRepository _productFeatureRepository;

        public ProductFeatureService(IProductFeatureRepository productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }

        public async Task<IEnumerable<FeatureDTO>> GetFeaturesByProductIdAsync(int productId)
        {
            return await _productFeatureRepository.GetFeaturesByProductIdAsync(productId);
        }
    }
}
