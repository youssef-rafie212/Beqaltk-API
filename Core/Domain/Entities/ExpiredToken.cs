using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class ExpiredToken
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Token { get; set; }
    }
}
