using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.DTOs;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDTO GetUser(string email, string password)
        {
            var found = _userRepository.GetUserByCredentials(email, password);

            if (found == null) return null;

            return _mapper.Map<UserDTO>(found);
        }

        public Boolean IsAdmin(String userName)
        {
            var found = _userRepository.GetUserByUserName(userName);

            if(found == null) return false;

            return found.IsAdmin;
        }
    }
}
