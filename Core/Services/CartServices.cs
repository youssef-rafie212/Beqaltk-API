using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.OrderItemDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IOrderItemServices _orderItemServices;
        private readonly ICartItemServices _cartItemServices;
        private readonly ServicesHelpers _helpers;

        public CartServices(
            ICartRepository cartRepo,
            ServicesHelpers helpers,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartItemRepository cartItemRepository,
            IOrderItemServices orderItemServices,
            ICartItemServices cartItemServices
            )
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepository;
            _orderItemRepo = orderItemRepository;
            _cartItemRepo = cartItemRepository;
            _cartItemServices = cartItemServices;
            _orderItemServices = orderItemServices;
            _helpers = helpers;
        }

        public async Task<Order> ConfirmCart(Guid cartId)
        {
            await _helpers.ThrowIfCartDoesntExist(cartId);

            Cart cart = (await _cartRepo.GetCartById(cartId))!;
            List<CartItem> cartItems = _cartItemRepo.GetAllCartItemsForCart(cartId);

            Order order = await _orderRepo.CreateOrder(new Order
            {
                Id = Guid.NewGuid(),
                UserId = cart.UserId,
            });

            foreach (CartItem cartItem in cartItems)
            {
                await _orderItemServices.CreateOrderItem(new CreateOrderItemDto
                {
                    Amount = cartItem.Amount,
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                });

                await _cartItemServices.DeleteCartItemById(cartItem.Id);
            }

            return order;
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
