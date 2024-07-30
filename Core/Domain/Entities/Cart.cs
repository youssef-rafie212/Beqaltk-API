using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        public double TotalPrice { get; set; } = 0;

        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
