using Core.DTOs;
using Core.Models;

namespace Core.Abstractions.Repositories
{
    public interface IUserRepository
    {
        User GetUserByCredentials(string email, string password);
        User GetUserById(int userId);
        User GetUserByUserName(String userName);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
