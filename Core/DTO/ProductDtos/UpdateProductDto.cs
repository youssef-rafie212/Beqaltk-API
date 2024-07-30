using System.ComponentModel.DataAnnotations;

namespace Core.DTO.ProductDtos
{
    public class UpdateProductDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Weight { get; set; }

        [Required]
        public double Price { get; set; }

        [Url]
        [Required]
        public string? ImgUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
