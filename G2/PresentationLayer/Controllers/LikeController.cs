using ApplicationLayer.Services;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/Like")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddLikeDTO addLikeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var like = await _likeService.AddLikeAsync(addLikeDTO);

                return Created("", like);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{reviewId}/user/{userId}")]
        public async Task<IActionResult> DeleteLike(int reviewId, int userId)
        {
            try
            {
                var result = await _likeService.DeleteLikeAsync(userId, reviewId);

                if (!result)
                {
                    return NotFound($"No like found for Review ID {reviewId} by User ID {userId}.");
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
