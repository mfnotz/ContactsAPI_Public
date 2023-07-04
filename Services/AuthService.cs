using Core.Abstractions.Services;
using Core.DTOs;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        public AuthService(IUserService userService, IJwtAuthenticationService jwtAuthenticationService)
        {
            _userService = userService;
            _jwtAuthenticationService = jwtAuthenticationService;
        }
        public String Login(string email, string password)
        {
            var user = _userService.GetUser(email, password);

            if (user == null) 
                return null;

            if (!user.IsActive)
                return null;

            return _jwtAuthenticationService.GenerateJwtToken(user.UserName);
        }

        public UserDTO Logout(string userId)
        {
            return null;
        }
    }
}
