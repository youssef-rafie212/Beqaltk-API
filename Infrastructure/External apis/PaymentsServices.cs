using Core.Domain.Entities;
using Core.DTO.OrderDtos;
using Core.DTO.PaymentDtos;
using Core.Enums;
using Core.Services_contracts;
using Stripe.Checkout;

namespace Infrastructure.External_apis
{
    public class PaymentsServices : IPaymentsServices
    {
        private readonly IProductServices _productServices;
        private readonly IOrderServices _orderServices;

        public PaymentsServices
            (
            IProductServices productServices,
            IOrderServices orderServices
            )
        {
            _productServices = productServices;
            _orderServices = orderServices;
        }

        public async Task<CreatePaymentRepsonseDto> CreatePayment(Guid orderId)
        {
            Order order = await _orderServices.GetOrderById(orderId);
            string url = await CreateCheckoutSession(order);

            return new CreatePaymentRepsonseDto
            {
                CheckoutPageUrl = url,
            };
        }

        public async Task<ConfirmPaymentResponseDto> ConfirmPayment(string sessionId)
        {
            SessionService service = new();
            Session session = service.Get(sessionId);

            if (session.PaymentStatus == "paid")
            {

                Order order = await _orderServices.GetOrderById(Guid.Parse(session.Metadata["orderId"]));
                await _orderServices.UpdateOrder(new UpdateOrderDto
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                    Status = OrderStatus.Paid
                });

                return new ConfirmPaymentResponseDto
                {
                    PaymentStatus = PaymentStatus.Succeeded,
                    RedirectUrl = "https://successcheckoutpage.netlify.app/"
                };
            }

            return new ConfirmPaymentResponseDto
            {
                PaymentStatus = PaymentStatus.Failed,
                RedirectUrl = "https://cancelcheckoutpage.netlify.app/"
            };
        }

        public async Task<string> CreateCheckoutSession(Order order)
        {
            List<OrderItem>? orderItems = order.OrderItems?.ToList();

            if (orderItems == null) throw new Exception("Order must have atleast on order item");

            string domain = "http://localhost:5012/";

            SessionCreateOptions options = new SessionCreateOptions
            {
                SuccessUrl = $"{domain}api/payments/confirm?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = "https://cancelcheckoutpage.netlify.app/",
                LineItems = new(),
                Mode = "payment",
                Metadata = new Dictionary<string, string>
                {
                    { "orderId" , order.Id.ToString() },
                }
            };

            foreach (OrderItem item in orderItems)
            {
                Product product = await _productServices.GetProductById(item.ProductId);

                SessionLineItemOptions itemOptions = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "EGP",
                        UnitAmount = Convert.ToInt64(product.Price * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.Name,
                        }
                    },
                    Quantity = item.Amount
                };

                options.LineItems.Add(itemOptions);
            }

            SessionService service = new();
            Session session = service.Create(options);

            return session.Url;
        }
    }
}