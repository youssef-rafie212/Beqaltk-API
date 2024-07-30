using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        [Range(1, 100)]
        public int Amount { get; set; } = 1;

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CartId { get; set; }

        public Product? Product { get; set; }

        public Cart? Cart { get; set; }
    }
}
