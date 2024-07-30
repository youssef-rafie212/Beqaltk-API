using System.ComponentModel.DataAnnotations;

namespace Core.DTO.AccountDtos
{
    public class ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? ResetToken { get; set; }

        [Required]
        public string? NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string? NewPasswordConfirm { get; set; }
    }
}
