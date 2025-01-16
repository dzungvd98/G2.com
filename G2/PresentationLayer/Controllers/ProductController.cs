using ApplicationLayer.Services;
using DataLayer.DTO;
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
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
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
        [HttpPost("product/reviews")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var review = await _reviewService.AddReviewAsync(reviewDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{productID}/reviews")]
        public async Task<IActionResult> DeleteReview(int productID)
        {
            try
            {
                var result = await _reviewService.DeleteReviewAsync(productID);

                if (!result)
                {
                    return NotFound($"Review with ID {productID} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
