using System.ComponentModel.DataAnnotations;

namespace Core.DTO.OrderDtos
{
    public class CreateOrderDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
