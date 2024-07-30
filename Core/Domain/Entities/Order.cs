using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public double TotalPrice { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
