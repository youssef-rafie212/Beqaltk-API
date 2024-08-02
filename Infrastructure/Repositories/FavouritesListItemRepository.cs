using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavouritesListItemRepository : IFavouritesListItemRepository
    {
        private readonly AppDBContext _db;

        public FavouritesListItemRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<FavouritesListItem> CreateFavouritesListItem(FavouritesListItem favouritesListItem)
        {
            _db.FavouritesListItems.Add(favouritesListItem);
            await _db.SaveChangesAsync();

            return favouritesListItem;
        }

        public async Task<bool> DeleteFavouritesListItemById(Guid favouritesListItemId)
        {
            FavouritesListItem? favouritesListItem = await _db.FavouritesListItems.FirstOrDefaultAsync(f => f.Id == favouritesListItemId);
            if (favouritesListItem == null) return false;
            _db.FavouritesListItems.Remove(favouritesListItem);
            await _db.SaveChangesAsync();
            return true;
        }

        public List<FavouritesListItem> GetAllFavouritesListItemsForFavouritesList(Guid favouritesListId)
        {
            return _db.FavouritesListItems.Where(f => f.FavouritesListId == favouritesListId).ToList();
        }

        public async Task<FavouritesListItem?> GetFavouritesListItemById(Guid favListItemId)
        {
            return await _db.FavouritesListItems.Include(f => f.FavouritesList).Include(f => f.Product).FirstOrDefaultAsync(f => f.Id == favListItemId);
        }
    }
}
