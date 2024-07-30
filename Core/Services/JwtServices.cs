using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.AccountDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{

    public class JwtServices : IJwtServices
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public JwtServices(IConfiguration configuration,
                UserManager<ApplicationUser> userManager,
                ITokenRepository tokenRepository
            )
        {
            _configuration = configuration;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        public async Task AddExpiredToken(string token)
        {
            await _tokenRepository.AddExpiredToken(token);
        }

        public async Task<AuthenticationResponseDto> GetJwtToken(ApplicationUser user)
        {
            // Expiration date.
            DateTime expires = DateTime.UtcNow.AddMonths(1);

            // Secret key. 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            // Signin credentials.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Claims.
            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = [
                new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name , user.UserName!),
                new Claim(ClaimTypes.NameIdentifier , user.UserName!),
                new Claim(ClaimTypes.Email , user.Email!)
            ];

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Token handler
            JwtSecurityTokenHandler handler = new();

            // Token descriptor
            SecurityTokenDescriptor descriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["JWT:Issuer"],
                Expires = expires,
                SigningCredentials = credentials,
            };

            // Token creating.
            var token = handler.CreateToken(descriptor);

            // Token writing
            string jwt = handler.WriteToken(token);

            return new AuthenticationResponseDto()
            {
                Token = jwt,
                TokenExpiresAt = expires.ToString(),
                UserID = user.Id.ToString(),
                Name = user.UserName,
                Email = user.Email
            };
        }

        public bool IsExpiredToken(string token)
        {
            return _tokenRepository.IsExpiredToken(token);
        }
    }
}
