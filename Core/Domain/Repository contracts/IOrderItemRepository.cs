using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAllOrderItemsForOrder(Guid orderId);
        Task<OrderItem?> GetOrderItemById(Guid orderItemId);
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItemById(Guid orderItemId);
    }
}
