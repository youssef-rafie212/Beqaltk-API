using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CartItemDtos
{
    public class UpdateCartItemDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }
    }
}
