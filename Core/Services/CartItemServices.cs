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
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        private readonly ServicesHelpers _helpers;

        public CartItemServices(
            ICartItemRepository cartItemRepo,
            ServicesHelpers helpers,
            ICartRepository cartRepo,
            IProductRepository productRepo
            )
        {
            _cartItemRepo = cartItemRepo;
            _cartRepo = cartRepo;
            _productRepo = productRepo;
            _helpers = helpers;
        }

        public async Task<CartItem> CreateCartItem(CreateCartItemDto cartItem)
        {
            await _helpers.ThrowIfCartDoesntExist(cartItem.CartId);
            await _helpers.ThrowIfProductDoesntExist(cartItem.ProductId);

            // Check if cart item already exists in the related cart
            CartItem? cartItemInCart = await _cartItemRepo.GetCartItemByCartAndProduct(cartItem.CartId, cartItem.ProductId);
            Cart cart = (await _cartRepo.GetCartById(cartItem.CartId))!;
            Product product = (await _productRepo.GetProductById(cartItem.ProductId))!;

            // Update related cart total price
            if (cartItemInCart == null)
            {
                await _cartRepo.UpdateCart(new Cart
                {
                    Id = cart.Id,
                    TotalPrice = cart.TotalPrice + (product.Price * cartItem.Amount),
                });

                return await _cartItemRepo.CreateCartItem(new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = cartItem.ProductId,
                    CartId = cartItem.CartId,
                    Amount = cartItem.Amount
                });
            }
            else
            {
                await _cartRepo.UpdateCart(new Cart
                {
                    Id = cart.Id,
                    TotalPrice = cart.TotalPrice - (product.Price * cartItemInCart.Amount)
                });
                await _cartRepo.UpdateCart(new Cart
                {
                    Id = cart.Id,
                    TotalPrice = cart.TotalPrice - (product.Price * (cartItemInCart.Amount + cartItem.Amount))
                });

                // Update the amount of the existing cart item
                return await _cartItemRepo.UpdateCartItem(new CartItem()
                {
                    Id = cartItemInCart.Id,
                    Amount = cartItemInCart.Amount + cartItem.Amount
                });
            }
        }

        public async Task<bool> DeleteCartItemById(Guid cartItemId)
        {
            // Update related cart total price
            CartItem? cartItem = await _cartItemRepo.GetCartItemById(cartItemId);
            if (cartItem == null) return false;
            Cart cart = (await _cartRepo.GetCartById(cartItem.CartId))!;
            Product product = (await _productRepo.GetProductById(cartItem.ProductId))!;
            await _cartRepo.UpdateCart(new Cart()
            {
                Id = cart.Id,
                TotalPrice = cart.TotalPrice - (product.Price * cartItem.Amount),
            });

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

            // Update related cart total price
            CartItem cartItemInCart = (await _cartItemRepo.GetCartItemById(cartItem.Id))!;
            Cart cart = (await _cartRepo.GetCartById(cartItemInCart.CartId))!;
            Product product = (await _productRepo.GetProductById(cartItemInCart.CartId))!;
            await _cartRepo.UpdateCart(new Cart
            {
                Id = cart.Id,
                TotalPrice = cart.TotalPrice - (product.Price * cartItemInCart.Amount),
            });
            await _cartRepo.UpdateCart(new Cart
            {
                Id = cart.Id,
                TotalPrice = cart.TotalPrice + (product.Price * cartItem.Amount),
            });

            return await _cartItemRepo.UpdateCartItem(new CartItem()
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
            });
        }
    }
}
