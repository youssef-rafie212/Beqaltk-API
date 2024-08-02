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
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ServicesHelpers _helpers;

        public OrderItemServices(
            IOrderItemRepository orderItemRepo,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ServicesHelpers helpers
            )
        {
            _orderItemRepo = orderItemRepo;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _helpers = helpers;
        }

        public async Task<OrderItem> CreateOrderItem(CreateOrderItemDto orderItem)
        {
            await _helpers.ThrowIfProductDoesntExist(orderItem.ProductId);
            await _helpers.ThrowIfOrderDoesntExist(orderItem.OrderId);

            // Check if order item already exists in the related order
            OrderItem? orderItemInOrder = await _orderItemRepo.GetOrderItemByOrderAndProduct(orderItem.OrderId, orderItem.ProductId);
            Order order = (await _orderRepository.GetOrderById(orderItem.OrderId))!;
            Product product = (await _productRepository.GetProductById(orderItem.ProductId))!;

            // Update related order total price
            if (orderItemInOrder == null)
            {
                await _orderRepository.UpdateOrder(new Order
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice + (product.Price * orderItem.Amount),
                });

                return await _orderItemRepo.CreateOrderItem(new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = orderItem.ProductId,
                    OrderId = orderItem.OrderId,
                    Amount = orderItem.Amount
                });
            }
            else
            {
                await _orderRepository.UpdateOrder(new Order
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice - (product.Price * orderItemInOrder.Amount)
                });
                await _orderRepository.UpdateOrder(new Order
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice + (product.Price * (orderItemInOrder.Amount + orderItem.Amount))
                });

                // Update the amount of the existing order item
                return await _orderItemRepo.UpdateOrderItem(new OrderItem()
                {
                    Id = orderItemInOrder.Id,
                    Amount = orderItemInOrder.Amount + orderItem.Amount
                });
            }
        }

        public async Task<bool> DeleteOrderItemById(Guid orderItemId)
        {
            // Update related order total price
            OrderItem? orderItem = await _orderItemRepo.GetOrderItemById(orderItemId);
            if (orderItem == null) return false;
            Order order = (await _orderRepository.GetOrderById(orderItem.OrderId))!;
            Product product = (await _productRepository.GetProductById(orderItem.ProductId))!;
            await _orderRepository.UpdateOrder(new Order()
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice - (product.Price * orderItem.Amount),
            });

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

            // Update related order total price
            OrderItem orderItemInOrder = (await _orderItemRepo.GetOrderItemById(orderItem.Id))!;
            Order order = (await _orderRepository.GetOrderById(orderItemInOrder.OrderId))!;
            Product product = (await _productRepository.GetProductById(orderItemInOrder.ProductId))!;
            await _orderRepository.UpdateOrder(new Order
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice - (product.Price * orderItemInOrder.Amount),
            });
            await _orderRepository.UpdateOrder(new Order
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice + (product.Price * orderItem.Amount),
            });

            return await _orderItemRepo.UpdateOrderItem(new OrderItem()
            {
                Id = orderItem.Id,
                Amount = orderItem.Amount,
            });
        }
    }
}
