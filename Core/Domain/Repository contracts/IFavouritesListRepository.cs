using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IFavouritesListRepository
    {
        Task<FavouritesList> CreateFavouritesListForUser(Guid userId);
        Task<FavouritesList> GetFavouriteListForUser(Guid userId);
        Task<FavouritesList?> GetFavouritesListById(Guid favListId);
    }
}
