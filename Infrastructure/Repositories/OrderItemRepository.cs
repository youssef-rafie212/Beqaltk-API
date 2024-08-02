using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDBContext _db;

        public OrderItemRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            _db.Add(orderItem);
            await _db.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> DeleteOrderItemById(Guid orderItemId)
        {
            OrderItem? order = await _db.OrderItems.FirstOrDefaultAsync(o => o.Id == orderItemId);
            if (order == null) return false;
            _db.OrderItems.Remove(order);
            await _db.SaveChangesAsync();
            return true;

        }

        public List<OrderItem> GetAllOrderItemsForOrder(Guid orderId)
        {
            return _db.OrderItems.Where(o => o.OrderId == orderId).ToList();
        }

        public async Task<OrderItem?> GetOrderItemById(Guid orderItemId)
        {
            return await _db.OrderItems.FirstOrDefaultAsync(o => o.Id == orderItemId);
        }

        public async Task<OrderItem?> GetOrderItemByOrderAndProduct(Guid orderId, Guid productId)
        {
            return await _db.OrderItems.FirstOrDefaultAsync(o => o.OrderId == orderId && o.ProductId == productId);
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            OrderItem orderItemToUpdate = (await _db.OrderItems.FirstOrDefaultAsync(o => o.Id == orderItem.Id))!;
            orderItemToUpdate.Amount = orderItem.Amount;

            await _db.SaveChangesAsync();
            return orderItemToUpdate;
        }
    }
}
