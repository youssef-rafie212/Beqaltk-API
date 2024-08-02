using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices _services;

        public CartsController(ICartServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _services.GetCartById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetForUser(Guid id)
        {
            try
            {
                return Ok(await _services.GetCartForUser(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost("confirm/{id}")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            try
            {
                return Ok(await _services.ConfirmCart(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }
    }
}
