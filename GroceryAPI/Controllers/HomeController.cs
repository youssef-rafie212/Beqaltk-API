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
            return Ok("Welcome to beqaltk, see the documentation at https://documenter.getpostman.com/view/29387971/2sA3rwNa6e to use the API");
        }
    }
}
