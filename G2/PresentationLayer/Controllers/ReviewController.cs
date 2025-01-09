using ApplicationLayer.Services;
using ApplicationLayer.Services.Impl;
using DataLayer.DTO;
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
                var reviews = await _reviewService.GetReviewByProductID(productID);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] AddReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var review = await _reviewService.AddReviewAsync(reviewDTO);
                return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewID }, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            return Ok(); 
        }
    }

}
