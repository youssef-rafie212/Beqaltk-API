using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to beqaltk, see the documentation at ... to use the API");
        }
    }
}
