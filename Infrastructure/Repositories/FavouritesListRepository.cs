using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavouritesListRepository : IFavouritesListRepository
    {
        private readonly AppDBContext _db;

        public FavouritesListRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<FavouritesList> CreateFavouritesListForUser(Guid userId)
        {
            FavouritesList favouritesList = new()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            _db.FavouritesLists.Add(favouritesList);
            await _db.SaveChangesAsync();

            return favouritesList;
        }

        public async Task<FavouritesList> GetFavouriteListForUser(Guid userId)
        {
            return (await _db.FavouritesLists.Include(f => f.FavouritesListItems).FirstOrDefaultAsync(f => f.UserId == userId))!;
        }

        public async Task<FavouritesList?> GetFavouritesListById(Guid favListId)
        {
            return await _db.FavouritesLists.Include(f => f.FavouritesListItems).FirstOrDefaultAsync(f => f.Id == favListId);
        }
    }
}
