using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CartItemDtos
{
    public class CreateCartItemDto
    {
        [Range(1, 100)]
        public int Amount { get; set; } = 1;

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CartId { get; set; }
    }
}
