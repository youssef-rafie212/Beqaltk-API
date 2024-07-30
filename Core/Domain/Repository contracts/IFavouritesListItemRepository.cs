using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IFavouritesListItemRepository
    {
        List<FavouritesListItem> GetAllFavouritesListItemsForFavouritesList(Guid favouritesListId);
        Task<FavouritesListItem?> GetFavouritesListItemById(Guid favListItemId);
        Task<FavouritesListItem> CreateFavouritesListItem(FavouritesListItem favouritesListItem);
        Task<bool> DeleteFavouritesListItemById(Guid favouritesListItemId);
    }
}
