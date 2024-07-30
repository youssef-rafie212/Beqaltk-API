using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrdersForUser(Guid userId);
        Task<Order?> GetOrderById(Guid orderId);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrderById(Guid orderId);
    }
}
