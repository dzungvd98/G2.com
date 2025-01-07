using ApplicationLayer.Services;
using ApplicationLayer.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        { 
            _reviewService = reviewService;
        }
        [HttpGet("Reviews")]
        public async Task<IActionResult> GetCategories(int productID)
        {
            try
            {
                var reviews = await _reviewService.GetReviewDetailByProductID(productID);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
