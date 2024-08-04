using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryServices _services;

        public DeliveryController(IDeliveryServices services)
        {
            _services = services;
        }

        [HttpPost("create/order/{id}")]
        public async Task<IActionResult> Create(Guid id)
        {
            try
            {
                return Ok(await _services.CreateDelivery(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost("complete/order/{id}")]
        public async Task<IActionResult> Complete(Guid id)
        {
            try
            {
                return Ok(await _services.CompleteDelivery(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost("cancel/order/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            try
            {
                return Ok(await _services.CancelDelivery(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }
    }
}
