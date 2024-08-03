using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.OrderDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IStripeServices _stripeServices;
        private readonly ServicesHelpers _helpers;

        public OrderServices(IOrderRepository orderRepo, ServicesHelpers helpers, IStripeServices stripeServices)
        {
            _orderRepo = orderRepo;
            _helpers = helpers;
            _stripeServices = stripeServices;
        }

        public async Task<string> ConfirmOrder(Guid orderId)
        {
            Order order = await GetOrderById(orderId);

            return await _stripeServices.Checkout(order);
        }

        public async Task<Order> CreateOrder(CreateOrderDto order)
        {
            await _helpers.ThrowIfUserDoesntExist(order.UserId);

            return await _orderRepo.CreateOrder(new Order
            {
                Id = Guid.NewGuid(),
                UserId = order.UserId,
            });
        }

        public async Task<bool> DeleteOrderById(Guid orderId)
        {
            return await _orderRepo.DeleteOrderById(orderId);
        }

        public async Task<List<Order>> GetAllOrdersForUser(Guid userId)
        {
            await _helpers.ThrowIfUserDoesntExist(userId);

            return _orderRepo.GetAllOrdersForUser(userId);
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            await _helpers.ThrowIfOrderDoesntExist(orderId);

            return (await _orderRepo.GetOrderById(orderId))!;
        }

        public async Task<Order> UpdateOrder(UpdateOrderDto order)
        {
            await _helpers.ThrowIfOrderDoesntExist(order.Id);

            return await _orderRepo.UpdateOrder(new Order
            {
                Id = order.Id,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
            });
        }
    }
}
