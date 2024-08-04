// NOTE : THIS IS JUST A FAKE SIMULATION OF A DELIVERY API FOR LEARNING PURPOSE

using Core.DTO.DeliveryDtos;

namespace Core.Services_contracts
{
    public interface IDeliveryServices
    {
        public Task<DeliveryResponseDto> CreateDelivery(Guid orderId);
        public Task<DeliveryResponseDto> CompleteDelivery(Guid orderId);
        public Task<DeliveryResponseDto> CancelDelivery(Guid orderId);
    }
}
