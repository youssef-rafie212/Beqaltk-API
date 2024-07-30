using Core.Domain.Entities;
using Core.DTO.OrderItemDtos;

namespace Core.Services_contracts
{
    public interface IOrderItemServices
    {
        Task<List<OrderItem>> GetAllOrderItemsForOrder(Guid orderId);
        Task<OrderItem> GetOrderItemById(Guid orderItemId);
        Task<OrderItem> CreateOrderItem(CreateOrderItemDto orderItem);
        Task<OrderItem> UpdateOrderItem(UpdateOrderItemDto orderItem);
        Task<bool> DeleteOrderItemById(Guid orderItemId);
    }
}
