using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly String _loggedUser;

        public BaseController()
        {
            _loggedUser = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
