// NOTE : THIS IS JUST A FAKE SIMULATION OF A DELIVERY API FOR LEARNING PURPOSE

using Core.Domain.Entities;
using Core.DTO.DeliveryDtos;
using Core.DTO.OrderDtos;
using Core.Enums;
using Core.Helpers;
using Core.Services_contracts;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.External_apis
{
    public class DeliveryServices : IDeliveryServices
    {
        private readonly IOrderServices _orderServices;
        private readonly IEmailSender _emailSender;
        private readonly ServicesHelpers _servicesHelpers;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeliveryServices(IOrderServices orderServices,
            IEmailSender emailSender,
            ServicesHelpers servicesHelpers,
            UserManager<ApplicationUser> userManager)
        {
            _orderServices = orderServices;
            _emailSender = emailSender;
            _servicesHelpers = servicesHelpers;
            _userManager = userManager;
        }

        public async Task<DeliveryResponseDto> CancelDelivery(Guid orderId)
        {
            await _servicesHelpers.ThrowIfOrderDoesntExist(orderId);

            Order order = await _orderServices.GetOrderById(orderId);

            switch (order.Status)
            {
                case OrderStatus.Pending:
                    throw new Exception("Given order purchase wasn't made");
                case OrderStatus.Shipped:
                    throw new Exception("Given order is already delivered");
                case OrderStatus.Cancelled:
                    throw new Exception("Given order is canceled");
            }

            ApplicationUser user = (await _userManager.FindByIdAsync(order.UserId.ToString()))!;

            await _orderServices.UpdateOrder(new UpdateOrderDto
            {
                Id = orderId,
                Status = OrderStatus.Cancelled,
                TotalPrice = order.TotalPrice,
            });

            string trackId = Guid.NewGuid().ToString();
            string message = $"Your order with the ID ({orderId}) was successfully cancelled\nThanks for using Beqaltk!";
            await _emailSender.SendEmailAsync(user.Email!, "Order Delivery Status Update!", message);

            return new DeliveryResponseDto
            {
                TrackID = null,
                OrderId = orderId.ToString(),
                Status = OrderStatus.Cancelled.ToString(),
            };
        }

        public async Task<DeliveryResponseDto> CompleteDelivery(Guid orderId)
        {
            await _servicesHelpers.ThrowIfOrderDoesntExist(orderId);

            Order order = await _orderServices.GetOrderById(orderId);

            switch (order.Status)
            {
                case OrderStatus.Pending:
                    throw new Exception("Given order purchase wasn't made");
                case OrderStatus.Paid:
                    throw new Exception("Given order delivery wasn't created");
                case OrderStatus.Shipped:
                    throw new Exception("Given order is already delivered");
                case OrderStatus.Cancelled:
                    throw new Exception("Given order is canceled");
            }

            ApplicationUser user = (await _userManager.FindByIdAsync(order.UserId.ToString()))!;

            await _orderServices.UpdateOrder(new UpdateOrderDto
            {
                Id = orderId,
                Status = OrderStatus.Shipped,
                TotalPrice = order.TotalPrice,
            });

            string trackId = Guid.NewGuid().ToString();
            string message = $"Your order with the ID ({orderId}) was successfully deliverd to {user.Address}\nDon't forget to add a review for the products you bought\nThanks for using Beqaltk!";
            await _emailSender.SendEmailAsync(user.Email!, "Order Delivery Status Update!", message);

            return new DeliveryResponseDto
            {
                TrackID = null,
                OrderId = orderId.ToString(),
                Status = OrderStatus.Shipped.ToString(),
            };
        }

        public async Task<DeliveryResponseDto> CreateDelivery(Guid orderId)
        {
            await _servicesHelpers.ThrowIfOrderDoesntExist(orderId);

            Order order = await _orderServices.GetOrderById(orderId);

            switch (order.Status)
            {
                case OrderStatus.Pending:
                    throw new Exception("Given order purchase wasn't made");
                case OrderStatus.Shipping:
                    throw new Exception("Given order is already out for delivery");
                case OrderStatus.Shipped:
                    throw new Exception("Given order is already delivered");
                case OrderStatus.Cancelled:
                    throw new Exception("Given order is canceled");
            }

            ApplicationUser user = (await _userManager.FindByIdAsync(order.UserId.ToString()))!;

            await _orderServices.UpdateOrder(new UpdateOrderDto
            {
                Id = orderId,
                Status = OrderStatus.Shipping,
                TotalPrice = order.TotalPrice,
            });

            string trackId = Guid.NewGuid().ToString();
            string message = $"Your order with the ID ({orderId}) is out for delivery to {user.Address}\nYou can track your order using this track ID ({trackId})\nThanks for using Beqaltk!";
            await _emailSender.SendEmailAsync(user.Email!, "Order Delivery Status Update!", message);

            return new DeliveryResponseDto
            {
                TrackID = trackId,
                OrderId = orderId.ToString(),
                Status = OrderStatus.Shipping.ToString(),
            };
        }
    }
}
