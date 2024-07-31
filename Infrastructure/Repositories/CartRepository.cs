using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDBContext _db;

        public CartRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Cart> CreateCartForUser(Guid userId)
        {
            Cart cart = new()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
            };

            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart?> GetCartById(Guid cartId)
        {
            return await _db.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<Cart> GetCartForUser(Guid userId)
        {
            return await _db.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == userId);
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            Cart cartToUpdate = (await GetCartById(cart.Id))!;
            cartToUpdate.TotalPrice = cart.TotalPrice;
            await _db.SaveChangesAsync();
            return (cartToUpdate);
        }
    }
}
