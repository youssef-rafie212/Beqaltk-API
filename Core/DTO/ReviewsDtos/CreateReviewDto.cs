using System.ComponentModel.DataAnnotations;

namespace Core.DTO.ReviewsDtos
{
    public class CreateReviewDto
    {

        [Required]
        public string? ReviewText { get; set; }

        [Range(1, 5)]
        [Required]
        public int? ReviewRating { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
