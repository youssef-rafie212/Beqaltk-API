using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.CartItemDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class CartItemServices : ICartItemServices
    {
        private readonly ICartItemRepository _cartItemRepo;
        private readonly ServicesHelpers _helpers;

        public CartItemServices(ICartItemRepository cartItemRepo, ServicesHelpers helpers)
        {
            _cartItemRepo = cartItemRepo;
            _helpers = helpers;
        }

        public async Task<CartItem> CreateCartItem(CreateCartItemDto cartItem)
        {
            await _helpers.ThrowIfCartDoesntExist(cartItem.CartId);
            await _helpers.ThrowIfProductDoesntExist(cartItem.ProductId);

            return await _cartItemRepo.CreateCartItem(new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = cartItem.ProductId,
                CartId = cartItem.CartId,
                Amount = cartItem.Amount
            });
        }

        public async Task<bool> DeleteCartItemById(Guid cartItemId)
        {
            return await _cartItemRepo.DeleteCartItemById(cartItemId);
        }

        public async Task<List<CartItem>> GetAllCartItemsForCart(Guid cartId)
        {
            await _helpers.ThrowIfCartDoesntExist(cartId);
            return _cartItemRepo.GetAllCartItemsForCart(cartId);
        }

        public async Task<CartItem> GetCartItemById(Guid cartItemId)
        {
            await _helpers.ThrowIfCartItemDoesntExist(cartItemId);
            return (await _cartItemRepo.GetCartItemById(cartItemId))!;
        }

        public async Task<CartItem> UpdateCartItem(UpdateCartItemDto cartItem)
        {
            await _helpers.ThrowIfCartItemDoesntExist(cartItem.Id);
            return await _cartItemRepo.UpdateCartItem(new CartItem()
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
            });
        }
    }
}
