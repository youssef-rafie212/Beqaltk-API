using Core.Domain.Entities;
using Core.Services_contracts;
using Stripe.Checkout;

namespace Infrastructure.External_apis
{
    public class StripeServices : IStripeServices
    {
        private readonly IProductServices _productServices;

        public StripeServices(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<string> Checkout(Order order)
        {
            List<OrderItem>? orderItems = order.OrderItems?.ToList();

            if (orderItems == null) throw new Exception("Order must have atleast on order item");

            SessionCreateOptions options = new SessionCreateOptions
            {
                SuccessUrl = "https://successcheckoutpage.netlify.app/",
                CancelUrl = "https://cancelcheckoutpage.netlify.app/",
                LineItems = new(),
                Mode = "payment"
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