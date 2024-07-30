using Core.Domain.Entities;
using Core.DTO.OrderDtos;

namespace Core.Services_contracts
{
    public interface IOrderServices
    {
        Task<List<Order>> GetAllOrdersForUser(Guid userId);
        Task<Order> GetOrderById(Guid orderId);
        Task<Order> CreateOrder(CreateOrderDto order);
        Task<Order> UpdateOrder(UpdateOrderDto order);
        Task<bool> DeleteOrderById(Guid orderId);
    }
}
