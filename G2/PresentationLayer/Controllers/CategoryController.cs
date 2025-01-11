using ApplicationLayer.Services;
using ApplicationLayer.Services.Impl;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] string type = "all")
        {
            try
            {
                var categories = await _categoryService.GetCategoriesByTypeAsync(type);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetProductsByCategoryIdAsync(int categoryId)
        {
            try
            {
                var products = await _categoryService.GetProductsByCategoryIdAsync(categoryId);
                return Ok(products);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategories([FromQuery] string type, [FromQuery] string sortBy, [FromQuery] bool isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string keyword = "")
        {
            try
            {
                var searchDTO = new CategorySearchDTO
                {
                    Type = type,
                    SortBy = sortBy,
                    IsAscending = isAscending,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Keyword = keyword
                };

                var result = await _categoryService.SearchCategoriesAsync(searchDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
