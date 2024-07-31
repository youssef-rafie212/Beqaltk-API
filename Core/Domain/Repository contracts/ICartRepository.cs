using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface ICartRepository
    {
        Task<Cart> CreateCartForUser(Guid userId);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart?> GetCartById(Guid cartId);
        Task<Cart> GetCartForUser(Guid userId);
    }
}
