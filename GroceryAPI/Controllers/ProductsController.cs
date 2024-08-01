using Core.Domain.Entities;
using Core.DTO.ProductDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;
        private readonly ISieveProcessor _sieveProcessor;

        public ProductsController(IProductServices services, ISieveProcessor sieveProcessor)
        {
            _services = services;
            _sieveProcessor = sieveProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel)
        {
            List<Product> allProducts = await _services.GetAllProducts();
            return Ok(_sieveProcessor.Apply(sieveModel, allProducts.AsQueryable()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _services.GetProductById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateproductDto createproductDto)
        {
            try
            {
                return Ok(await _services.CreateProduct(createproductDto));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProductDto updateProductDto)
        {
            try
            {
                return Ok(await _services.UpdateProduct(updateProductDto));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _services.DeleteProductById(id);
            if (!isDeleted) return Problem("ID not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
