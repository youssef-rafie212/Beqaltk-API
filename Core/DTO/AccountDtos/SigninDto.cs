using System.ComponentModel.DataAnnotations;

namespace Core.DTO.AccountDtos
{
    public class SigninDto
    {
        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
