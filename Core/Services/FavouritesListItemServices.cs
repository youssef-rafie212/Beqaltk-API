using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.FavourtiesListItemsDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class FavouritesListItemServices : IFavouritesListItemServices
    {
        private readonly IFavouritesListItemRepository _favListItemRepo;
        private readonly ServicesHelpers _helpers;

        public FavouritesListItemServices(IFavouritesListItemRepository favListItemRepo, ServicesHelpers helpers)
        {
            _favListItemRepo = favListItemRepo;
            _helpers = helpers;
        }

        public async Task<FavouritesListItem> CreateFavouritesListItem(CreateFavouritesListItemDto favouritesListItem)
        {
            await _helpers.ThrowIfFavListDoesntExist(favouritesListItem.FavouritesListId);
            await _helpers.ThrowIfProductDoesntExist(favouritesListItem.ProductId);

            return await _favListItemRepo.CreateFavouritesListItem(new FavouritesListItem()
            {
                Id = Guid.NewGuid(),
                ProductId = favouritesListItem.ProductId,
                FavouritesListId = favouritesListItem.FavouritesListId,
            });
        }

        public async Task<bool> DeleteFavouritesListItemById(Guid favouritesListItemId)
        {
            return await _favListItemRepo.DeleteFavouritesListItemById(favouritesListItemId);
        }

        public async Task<List<FavouritesListItem>> GetAllFavouritesListItemsForFavouritesList(Guid favouritesListId)
        {
            await _helpers.ThrowIfFavListDoesntExist(favouritesListId);
            return _favListItemRepo.GetAllFavouritesListItemsForFavouritesList(favouritesListId);
        }

        public async Task<FavouritesListItem> GetFavouritesListItemById(Guid favListItemId)
        {
            await _helpers.ThrowIfFavListItemDoesntExist(favListItemId);
            return (await _favListItemRepo.GetFavouritesListItemById(favListItemId))!;
        }
    }
}
