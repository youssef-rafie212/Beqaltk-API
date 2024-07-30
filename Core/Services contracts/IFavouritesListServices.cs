using Core.Domain.Entities;

namespace Core.Services_contracts
{
    public interface IFavouritesListServices
    {
        Task<FavouritesList> CreateFavouritesListForUser(Guid userId);
        Task<FavouritesList> GetFavouriteListForUser(Guid userId);
        Task<FavouritesList> GetFavouritesListById(Guid favListId);
    }
}
