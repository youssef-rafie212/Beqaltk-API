using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Weight { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; } = 0;

        public int NumberOfRatings { get; set; } = 0;

        [Required]
        public double Price { get; set; }

        [Url]
        public string? ImgUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        public IEnumerable<Review>? Reviews { get; set; }
    }
}
