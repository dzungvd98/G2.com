using ApplicationLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetActionResultAsync()
        {
            var products = await _productService.GetAllProductsAsync(); 
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductDetails(int productId)
        {
            var productDetails = await _productService.GetProductDetailsAsync(productId);
            if (productDetails == null) {
                return NotFound();
            }
            return Ok(productDetails);
        }

        [HttpGet("{productId}/features")]
        public async Task<IActionResult> GetProductFeaturesAsync(int productId)
        {
            var features = await _productService.GetFeatureOfProductByIdAsync(productId);
            if (features == null)
            {
                return NotFound();
            }
            return Ok(features);
        }
    }
}
