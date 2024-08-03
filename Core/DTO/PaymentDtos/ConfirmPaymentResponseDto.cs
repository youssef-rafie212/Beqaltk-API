using Core.Enums;

namespace Core.DTO.PaymentDtos
{
    public class ConfirmPaymentResponseDto
    {
        public PaymentStatus PaymentStatus { get; set; }
        public string? RedirectUrl { get; set; }
    }
}
