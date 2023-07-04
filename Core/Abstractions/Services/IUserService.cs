using Core.DTOs;

namespace Core.Abstractions.Services
{
    public interface IUserService
    {
        public UserDTO GetUser(String email, String password);
        public Boolean IsAdmin(String userName);
    }
}
