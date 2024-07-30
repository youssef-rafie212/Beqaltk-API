using System.ComponentModel.DataAnnotations;

namespace Core.DTO.AccountDtos
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
