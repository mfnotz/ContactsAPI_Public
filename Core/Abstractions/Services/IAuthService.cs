using Core.DTOs;

namespace Core.Abstractions.Services
{
    public interface IAuthService
    {
        String Login(string username, string password);
        UserDTO Logout(string userId);
    }
}
