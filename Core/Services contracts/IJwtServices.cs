using Core.Domain.Entities;
using Core.DTO.AccountDtos;

namespace Core.Services_contracts
{
    public interface IJwtServices
    {
        Task<AuthenticationResponseDto> GetJwtToken(ApplicationUser user);

        Task AddExpiredToken(string token);

        bool IsExpiredToken(string token);
    }
}
