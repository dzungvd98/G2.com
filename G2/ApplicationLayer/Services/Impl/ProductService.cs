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
            return await _productRepository.GetProductByIdAsync(productId);
        }
    }
}
