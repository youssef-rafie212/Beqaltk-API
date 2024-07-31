using Core.Domain.Entities;

namespace Core.Services_contracts
{
    public interface ICartServices
    {
        Task<Cart> CreateCartForUser(Guid userId);
        Task<Cart> GetCartById(Guid cartId);
        Task<Cart> GetCartForUser(Guid userId);
        // Creates an order with the cart items in the given cart and clears the cart
        Task<Order> ConfirmCart(Guid cartId);
    }
}
