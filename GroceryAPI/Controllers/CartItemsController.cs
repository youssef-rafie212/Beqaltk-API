using Core.DTO.CartItemDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemServices _services;

        public CartItemsController(ICartItemServices services)
        {
            _services = services;
        }

        [HttpGet("cart/{id}")]
        public async Task<IActionResult> GetAllForCart(Guid id)
        {
            try
            {
                return Ok(await _services.GetAllCartItemsForCart(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _services.GetCartItemById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CreateCartItemDto createCart)
        {
            try
            {
                return Ok(await _services.CreateCartItem(createCart));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCartItemDto updateCartItem)
        {
            try
            {
                updateCartItem.Id = id;
                return Ok(await _services.UpdateCartItem(updateCartItem));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _services.DeleteCartItemById(id);
            if (!isDeleted) return Problem("ID not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
