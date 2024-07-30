using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string? ImgUrl { get; set; }
    }
}
