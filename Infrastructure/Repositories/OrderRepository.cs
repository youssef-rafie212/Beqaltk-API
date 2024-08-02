using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _db;

        public OrderRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderById(Guid orderId)
        {
            Order? orderToDelete = await GetOrderById(orderId);
            if (orderToDelete == null) return false;
            _db.Orders.Remove(orderToDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public List<Order> GetAllOrdersForUser(Guid userId)
        {
            return _db.Orders.Include(o => o.OrderItems).Where(o => o.UserId == userId).ToList();
        }

        public async Task<Order?> GetOrderById(Guid orderId)
        {
            Order? order = await _db.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            Order? orderToUpdate = await _db.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

            orderToUpdate!.Status = order.Status;
            orderToUpdate!.TotalPrice = order.TotalPrice;

            await _db.SaveChangesAsync();
            return orderToUpdate;
        }
    }
}
