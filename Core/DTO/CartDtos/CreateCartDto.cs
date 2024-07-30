using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CartDtos
{
    public class CreateCartDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
