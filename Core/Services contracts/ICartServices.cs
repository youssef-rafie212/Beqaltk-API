using Core.Domain.Entities;

namespace Core.Services_contracts
{
    public interface ICartServices
    {
        Task<Cart> CreateCartForUser(Guid userId);
        Task<Cart> GetCartById(Guid cartId);
        Task<Cart> GetCartForUser(Guid userId);
    }
}
