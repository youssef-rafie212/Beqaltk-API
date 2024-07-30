using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(120)]
        [Sieve(CanSort = true, CanFilter = true)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string? ImgUrl { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
