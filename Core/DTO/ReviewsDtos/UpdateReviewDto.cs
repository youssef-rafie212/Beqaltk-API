using System.ComponentModel.DataAnnotations;

namespace Core.DTO.ReviewsDtos
{
    public class UpdateReviewDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? ReviewText { get; set; }

        [Range(1, 5)]
        [Required]
        public int ReviewRating { get; set; }
    }
}
