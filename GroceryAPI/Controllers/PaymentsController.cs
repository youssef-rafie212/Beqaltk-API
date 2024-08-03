using Core.DTO.PaymentDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsServices _services;

        public PaymentsController(IPaymentsServices services)
        {
            _services = services;
        }

        [HttpPost("order/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateForOrder(Guid id)
        {
            try
            {
                return Ok(await _services.CreatePayment(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> Confirm([FromQuery] string session_id)
        {
            ConfirmPaymentResponseDto response = await _services.ConfirmPayment(session_id);
            return Redirect(response.RedirectUrl!);
        }
    }
}
