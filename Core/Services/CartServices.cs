using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepo;
        private readonly ServicesHelpers _helpers;

        public CartServices(ICartRepository cartRepo, ServicesHelpers helpers)
        {
            _cartRepo = cartRepo;
            _helpers = helpers;
        }

        public async Task<Cart> CreateCartForUser(Guid userId)
        {
            await _helpers.ThrowIfUserDoesntExist(userId);

            return await _cartRepo.CreateCartForUser(userId);
        }

        public async Task<Cart> GetCartById(Guid cartId)
        {
            await _helpers.ThrowIfCartDoesntExist(cartId);
            return (await _cartRepo.GetCartById(cartId))!;
        }

        public async Task<Cart> GetCartForUser(Guid userId)
        {
            await _helpers.ThrowIfUserDoesntExist(userId);

            return await _cartRepo.GetCartForUser(userId);
        }
    }
}
