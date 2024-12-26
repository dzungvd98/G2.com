using ApplicationLayer.Services;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : Controller
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetPringByProductIdAsync(int productId) {
            var pricings = await _pricingService.GetPricingByProductIdAsync(productId);
            return Ok(pricings);
        }

    }
}
