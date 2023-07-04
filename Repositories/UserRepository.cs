using Core.Abstractions.Repositories;
using Core.Models;
namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContactsDbContext _dbContext;

        public UserRepository(IContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByCredentials(String email, String password)
        { 
            return _dbContext.Users.FirstOrDefault(x => x.IsActive && x.Email == email && x.Password == password);
        }

        public User GetUserByUserName(String userName)
        {
            return _dbContext.Users.FirstOrDefault(x => x.IsActive && x.UserName == userName);
        }

        public User GetUserById(int userId)
        {
            var found = _dbContext.Users.Find(userId);

            if (found == null || !found.IsActive)
                return null;

            return found;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
