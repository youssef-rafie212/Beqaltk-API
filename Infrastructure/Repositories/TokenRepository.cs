using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;

namespace Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDBContext _dbContext;
        public TokenRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task AddExpiredToken(string token)
        {
            ExpiredToken expiredToken = new() { Id = Guid.NewGuid(), Token = token };
            await _dbContext.ExpiredTokens.AddAsync(expiredToken);
            await _dbContext.SaveChangesAsync();
        }

        public bool IsExpiredToken(string token)
        {
            return _dbContext.ExpiredTokens.Any(t => t.Token == token);
        }
    }
}
