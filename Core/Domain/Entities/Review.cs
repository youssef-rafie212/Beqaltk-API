using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? ReviewText { get; set; }

        [Range(1, 5)]
        [Required]
        [Sieve(CanSort = true, CanFilter = true)]
        public int? ReviewRating { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser? User { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
