using Core.Domain.Entities;
using Core.DTO.CategoryDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ISieveProcessor _sieveProcessor;

        public CategoriesController(ICategoryServices categoryServices, ISieveProcessor sieveProcessor)
        {
            _categoryServices = categoryServices;
            _sieveProcessor = sieveProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel)
        {
            List<Category> categories = await _categoryServices.GetAllCategories();
            return Ok(_sieveProcessor.Apply(sieveModel, categories.AsQueryable()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Category? category = await _categoryServices.GetCategoryById(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateCategoryDto createCategoryDto)
        {
            return Ok(await _categoryServices.CreateCategory(createCategoryDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                Category category = await _categoryServices.UpdateCategory(updateCategoryDto);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _categoryServices.DeleteCategoryById(id);

            if (!deleted) return BadRequest("ID not found or invalid");

            return NoContent();
        }
    }
}
