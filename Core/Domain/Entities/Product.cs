using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Sieve(CanSort = true, CanFilter = true)]
        public string? Name { get; set; }

        [Required]
        public string? Weight { get; set; }

        [Range(0, 5)]
        [Sieve(CanSort = true, CanFilter = true)]
        public int Rating { get; set; } = 0;

        [Sieve(CanSort = true)]
        public int NumberOfRatings { get; set; } = 0;

        [Required]
        [Sieve(CanSort = true)]
        public double Price { get; set; }

        [Url]
        public string? ImgUrl { get; set; }

        [Required]
        [Sieve(CanFilter = true)]
        public Guid CategoryId { get; set; }

        public IEnumerable<Review>? Reviews { get; set; }
    }
}
