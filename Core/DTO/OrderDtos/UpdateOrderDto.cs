using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO.OrderDtos
{
    public class UpdateOrderDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
