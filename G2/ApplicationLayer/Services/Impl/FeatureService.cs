using DataLayer.DTO;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Impl
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _productFeatureRepository;

        public FeatureService(IFeatureRepository productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }

        public async Task<IEnumerable<FeatureDTO>> GetFeaturesByProductIdAsync(int productId)
        {
            return await _productFeatureRepository.GetFeaturesByProductIdAsync(productId);
        }
    }
}
