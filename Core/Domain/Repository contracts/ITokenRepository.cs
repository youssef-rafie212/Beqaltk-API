namespace Core.Domain.Repository_contracts
{
    public interface ITokenRepository
    {
        Task AddExpiredToken(string token);

        bool IsExpiredToken(string token);
    }
}
