using Core.Domain.Entities;
using Core.DTO.CartItemDtos;

namespace Core.Services_contracts
{
    public interface ICartItemServices
    {
        Task<List<CartItem>> GetAllCartItemsForCart(Guid cartId);
        Task<CartItem> GetCartItemById(Guid cartItemId);
        Task<CartItem> CreateCartItem(CreateCartItemDto cartItem);
        Task<CartItem> UpdateCartItem(UpdateCartItemDto cartItem);
        Task<bool> DeleteCartItemById(Guid cartItemId);
    }
}
