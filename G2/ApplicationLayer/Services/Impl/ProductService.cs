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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFeatureRepository _featureRepository;
        private readonly IPricingRepository _pricingRepository;
        private readonly IProsConsRepository _prosConsRepository;

        public ProductService(IProductRepository productRepository, IFeatureRepository featureRepository, IPricingRepository pricingRepository, IProsConsRepository prosConsRepository)
        {
            _productRepository = productRepository;
            _featureRepository = featureRepository;
            _pricingRepository = pricingRepository;
            _prosConsRepository = prosConsRepository;
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            return _productRepository.GetAllProductsAsync();
        }

        public async Task<IEnumerable<FeatureDTO>> GetFeatureOfProductByIdAsync(int productId)
        {
            return await _featureRepository.GetFeaturesByProductIdAsync(productId);
        }

        public async Task<ProductDetailsDTO> GetProductDetailsAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            var features = await _featureRepository.GetFeaturesByProductIdAsync(productId);
            product.Features = features;
            product.Pricings = await _pricingRepository.GetPricesByProductId(productId);
            product.ProsCons = await _prosConsRepository.GetProsAndConsOfProductByIdAsync(productId);
            return product;
        }
    }
}
