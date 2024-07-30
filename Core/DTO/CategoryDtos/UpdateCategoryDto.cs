using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string? ImgUrl { get; set; }
    }
}

