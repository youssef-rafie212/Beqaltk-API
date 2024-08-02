using Core.DTO.OrderDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetOrdersForUser(Guid id)
        {
            try
            {
                return Ok(await _orderServices.GetAllOrdersForUser(id));
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
                return Ok(await _orderServices.GetOrderById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateOrderDto updateOrder)
        {
            try
            {
                updateOrder.Id = id;
                return Ok(await _orderServices.UpdateOrder(updateOrder));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _orderServices.DeleteOrderById(id);
            if (!isDeleted) return Problem("ID is not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
