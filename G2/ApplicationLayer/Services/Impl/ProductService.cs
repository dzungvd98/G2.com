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
        private readonly IProductFeatureRepository _productFeatureRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            return _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductDetailsDTO> GetProductDetailsAsync(int productId)
        {
            var result = await _productRepository.GetProductByIdAsync(productId);
            //var features = await _productFeatureRepository.GetFeaturesByProductIdAsync(productId);
            //result.Features = features;
            return result;
        }
    }
}
