using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface ICartItemRepository
    {
        List<CartItem> GetAllCartItemsForCart(Guid cartId);
        Task<CartItem?> GetCartItemById(Guid cartItemId);
        Task<CartItem?> GetCartItemByCartAndProduct(Guid cartId, Guid productId);
        Task<CartItem> CreateCartItem(CartItem cartItem);
        Task<CartItem> UpdateCartItem(CartItem cartItem);
        Task<bool> DeleteCartItemById(Guid cartId);
    }
}
