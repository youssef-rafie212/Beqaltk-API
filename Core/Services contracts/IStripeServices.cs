using Core.Domain.Entities;

namespace Core.Services_contracts
{
    public interface IStripeServices
    {
        public Task<string> Checkout(Order order);
    }
}
