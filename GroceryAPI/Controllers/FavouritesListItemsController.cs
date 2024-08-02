using Core.DTO.FavourtiesListItemsDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavouritesListItemsController : ControllerBase
    {
        private readonly IFavouritesListItemServices _services;

        public FavouritesListItemsController(IFavouritesListItemServices services)
        {
            _services = services;
        }

        [HttpGet("favouritesList/{id}")]
        public async Task<IActionResult> GetAllForFavList(Guid id)
        {
            try
            {
                return Ok(await _services.GetAllFavouritesListItemsForFavouritesList(id));
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
                return Ok(await _services.GetFavouritesListItemById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFavouritesListItemDto createFavouritesListItem)
        {
            try
            {
                return Ok(await _services.CreateFavouritesListItem(createFavouritesListItem));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _services.DeleteFavouritesListItemById(id);
            if (!isDeleted) return Problem("ID not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
