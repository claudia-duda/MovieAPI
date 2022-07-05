using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult SignOutUser()
        {
            Result result = _logoutService.SignOutUser();
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());

        }
    }
}
