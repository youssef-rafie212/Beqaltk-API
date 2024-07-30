using Core.Domain.Entities;
using Core.DTO.FavourtiesListItemsDtos;

namespace Core.Services_contracts
{
    public interface IFavouritesListItemServices
    {
        Task<List<FavouritesListItem>> GetAllFavouritesListItemsForFavouritesList(Guid favouritesListId);
        Task<FavouritesListItem> GetFavouritesListItemById(Guid favListItemId);
        Task<FavouritesListItem> CreateFavouritesListItem(CreateFavouritesListItemDto favouritesListItem);
        Task<bool> DeleteFavouritesListItemById(Guid favouritesListItemId);
    }
}
