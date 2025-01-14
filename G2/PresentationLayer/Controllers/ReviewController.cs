using ApplicationLayer.Services;
using ApplicationLayer.Services.Impl;
using DataLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/Review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        { 
            _reviewService = reviewService;
        }
        [HttpGet("{productID}/Reviews")]
        public async Task<IActionResult> GetReviewByProductID(int productID)
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
                return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewId }, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{productID}")]
        public async Task<IActionResult> GetReviewById(int productID)
        {
            return Ok(); 
        }
        [HttpDelete("{productID}")]
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
