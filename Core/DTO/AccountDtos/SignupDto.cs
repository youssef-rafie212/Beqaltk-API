using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO.AccountDtos
{
    public class SignupDto
    {
        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? PasswordConfirm { get; set; }

        public AppRoles AppRole { get; set; } = AppRoles.User;
    }
}
