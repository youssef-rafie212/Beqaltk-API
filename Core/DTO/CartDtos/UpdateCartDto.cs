using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CartDtos
{
    public class UpdateCartDto
    {
        [Required]
        Guid Id { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
