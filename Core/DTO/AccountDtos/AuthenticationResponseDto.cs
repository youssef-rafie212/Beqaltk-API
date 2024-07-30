namespace Core.DTO.AccountDtos
{
    public class AuthenticationResponseDto
    {
        public string? Token { get; set; }
        public string? TokenExpiresAt { get; set; }
        public string? UserID { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
