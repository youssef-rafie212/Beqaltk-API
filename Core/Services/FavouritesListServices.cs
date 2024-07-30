using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class FavouritesListServices : IFavouritesListServices
    {
        private readonly IFavouritesListRepository _favListRepo;
        private readonly ServicesHelpers _helpers;

        public FavouritesListServices(IFavouritesListRepository favListRepo, ServicesHelpers helpers)
        {
            _favListRepo = favListRepo;
            _helpers = helpers;
        }

        public async Task<FavouritesList> CreateFavouritesListForUser(Guid userId)
        {
            await _helpers.ThrowIfUserDoesntExist(userId);

            return await _favListRepo.CreateFavouritesListForUser(userId);
        }

        public async Task<FavouritesList> GetFavouriteListForUser(Guid userId)
        {
            await _helpers.ThrowIfUserDoesntExist(userId);

            return await _favListRepo.GetFavouriteListForUser(userId);
        }

        public async Task<FavouritesList> GetFavouritesListById(Guid favListId)
        {
            await _helpers.ThrowIfFavListDoesntExist(favListId);
            return (await _favListRepo.GetFavouritesListById(favListId))!;
        }
    }
}
