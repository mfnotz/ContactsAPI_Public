using Core.Abstractions.Repositories;

namespace Repositories
{
    public class RevokedTokenRepository : IRevokedTokenRepository
    {
        private readonly HashSet<string> _revokedTokens = new HashSet<string>();

        public void RevokeToken(string token)
        {
            _revokedTokens.Add(token);
        }

        public bool IsTokenRevoked(string token)
        {
            return _revokedTokens.Contains(token);
        }
    }
}
