using Core.Domain.Entities;
using Core.DTO.PaymentDtos;

namespace Core.Services_contracts
{
    public interface IPaymentsServices
    {
        public Task<string> CreateCheckoutSession(Order order);
        public Task<CreatePaymentRepsonseDto> CreatePayment(Guid orderId);
        public Task<ConfirmPaymentResponseDto> ConfirmPayment(string sessionId);
    }
}
