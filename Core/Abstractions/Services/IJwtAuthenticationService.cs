using Core.DTOs;

namespace Core.Abstractions.Services
{
    public interface IJwtAuthenticationService
    {
        String GenerateJwtToken(String userName);
    }
}
