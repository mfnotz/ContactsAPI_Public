using API.Validators;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly LoginInfoDTOValidator _loginInfoValidator;

        public AuthController(IAuthService authService, LoginInfoDTOValidator loginInfoValidator)
        {
            _authService = authService;
            _loginInfoValidator = loginInfoValidator;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginInfoDTO loginInfoDTO)
        {
            var validationResult = _loginInfoValidator.Validate(loginInfoDTO);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToString("~"));

            
            var token = _authService.Login(loginInfoDTO.Email, loginInfoDTO.Password);

            if (String.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(token);
        }

    }
}
