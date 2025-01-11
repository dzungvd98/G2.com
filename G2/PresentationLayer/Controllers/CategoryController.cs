using ApplicationLayer.Services;
using ApplicationLayer.Services.Impl;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("categories")]
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

        [HttpGet("{categoryId}/relate")]
        public async Task<IActionResult> GetRelateCategoryByIdAsync(int categoryId)
        {
            try
            {
                var result = await _categoryService.GetRelateCategoriesByIdAsync(categoryId);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
