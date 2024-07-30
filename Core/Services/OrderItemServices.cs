using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.OrderItemDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class OrderItemServices : IOrderItemServices
    {
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly ServicesHelpers _helpers;

        public OrderItemServices(IOrderItemRepository orderItemRepo, ServicesHelpers helpers)
        {
            _orderItemRepo = orderItemRepo;
            _helpers = helpers;
        }

        public async Task<OrderItem> CreateOrderItem(CreateOrderItemDto orderItem)
        {
            await _helpers.ThrowIfProductDoesntExist(orderItem.ProductId);
            await _helpers.ThrowIfOrderDoesntExist(orderItem.OrderId);

            return await _orderItemRepo.CreateOrderItem(new OrderItem()
            {
                Id = Guid.NewGuid(),
                Amount = orderItem.Amount,
                ProductId = orderItem.ProductId,
                OrderId = orderItem.OrderId,
            });
        }

        public async Task<bool> DeleteOrderItemById(Guid orderItemId)
        {
            return await _orderItemRepo.DeleteOrderItemById(orderItemId);
        }

        public async Task<List<OrderItem>> GetAllOrderItemsForOrder(Guid orderId)
        {
            await _helpers.ThrowIfOrderDoesntExist(orderId);
            return _orderItemRepo.GetAllOrderItemsForOrder(orderId);
        }

        public async Task<OrderItem> GetOrderItemById(Guid orderItemId)
        {
            await _helpers.ThrowIfOrderItemDoesntExist(orderItemId);
            return (await _orderItemRepo.GetOrderItemById(orderItemId))!;
        }

        public async Task<OrderItem> UpdateOrderItem(UpdateOrderItemDto orderItem)
        {
            await _helpers.ThrowIfOrderItemDoesntExist(orderItem.Id);
            return await _orderItemRepo.UpdateOrderItem(new OrderItem()
            {
                Id = orderItem.Id,
                Amount = orderItem.Amount,
            });
        }
    }
}
