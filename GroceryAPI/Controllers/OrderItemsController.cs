using Core.DTO.OrderItemDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemServices _orderItemServices;

        public OrderItemsController(IOrderItemServices orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetAllForOrder(Guid id)
        {
            try
            {
                return Ok(await _orderItemServices.GetAllOrderItemsForOrder(id));
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
                return Ok(await _orderItemServices.GetOrderItemById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateOrderItemDto updateOrderItem)
        {
            try
            {
                updateOrderItem.Id = id;
                return Ok(await _orderItemServices.UpdateOrderItem(updateOrderItem));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _orderItemServices.DeleteOrderItemById(id);
            if (!isDeleted) return Problem("ID not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
