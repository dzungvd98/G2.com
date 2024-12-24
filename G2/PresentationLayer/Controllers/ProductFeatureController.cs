using ApplicationLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private readonly IProductFeatureService _productFeatureService;

        public ProductFeatureController(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetFeaturesOfProduct(int productId)
        {
            var productFeatures = await _productFeatureService.GetFeaturesByProductIdAsync(productId);
            if (productFeatures == null)
            {
                return NotFound();
            }
            return Ok(productFeatures);
        }
    }
}
