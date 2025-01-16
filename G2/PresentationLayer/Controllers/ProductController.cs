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

        [HttpGet("{productId}/alternatives")]
        public async Task<IActionResult> GetAlternativeProductByIdAsync(int productId)
        {
            var alternativeProducts = await _productService.GetAlternativeProductByIdAsync(productId);
            if (alternativeProducts == null)
            {
                return NotFound();
            }
            return Ok(alternativeProducts);
        }

        [HttpGet("{productId}/reviews")]
        public async Task<IActionResult> GetReviewOfProductById(int productId)
        {
            var reviews = await _productService.GetReviewOfProductByIdAsync(productId);
            if(reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }

        [HttpGet("{productId}/prosncons")]
        public async Task<IActionResult> GetProsNConsOfProductByIdAsync(int productId)
        {
            var result = await _productService.GetProsAndConsByIdAsync(productId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("{productId}/discussions")]
        public async Task<IActionResult> GetDiscussionOfProductById(int productId)
        {
            var result = await _productService.GetDiscussionByIdAsync(productId);
            if(result == null)
            {
                return NotFound(); 
            }
            return Ok(result);
        }
    }
}
