using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDBContext _db;

        public CartItemRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<CartItem> CreateCartItem(CartItem cartItem)
        {
            _db.CartItems.Add(cartItem);
            await _db.SaveChangesAsync();
            return cartItem;

        }

        public async Task<bool> DeleteCartItemById(Guid cartId)
        {
            CartItem? cartItem = await _db.CartItems.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cartItem == null) return false;
            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();
            return true;
        }

        public List<CartItem> GetAllCartItemsForCart(Guid cartId)
        {
            return _db.CartItems.Where(c => c.CartId == cartId).ToList();
        }

        public async Task<CartItem?> GetCartItemByCartAndProduct(Guid cartId, Guid productId)
        {
            return await _db.CartItems.FirstOrDefaultAsync(c => c.CartId == cartId && c.ProductId == productId);
        }

        public async Task<CartItem?> GetCartItemById(Guid cartItemId)
        {
            return await _db.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId);
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            CartItem cartItemToUpdate = await _db.CartItems.FirstOrDefaultAsync(c => c.Id == cartItem.Id);
            cartItemToUpdate.Amount = cartItem.Amount;

            await _db.SaveChangesAsync();
            return cartItem;
        }
    }
}
