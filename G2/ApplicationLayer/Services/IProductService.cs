using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<ProductDetailsDTO> GetProductDetailsAsync(int productId);

        Task<IEnumerable<FeatureDTO>> GetFeatureOfProductByIdAsync(int productId);

        Task<IEnumerable<ReviewDTO>> GetReviewOfProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetAlternativeProductByIdAsync(int productId);
        Task<IEnumerable<ProsConsDTO>> GetProsAndConsByIdAsync(int productId);

    }
}
