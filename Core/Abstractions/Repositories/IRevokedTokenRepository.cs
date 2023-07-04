namespace Core.Abstractions.Repositories
{
    public interface IRevokedTokenRepository
    {
        void RevokeToken(string token);
        bool IsTokenRevoked(string token);
    }
}
