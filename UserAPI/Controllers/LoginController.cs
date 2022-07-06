using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserAPI.Data.Requests;
using UserAPI.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult SignInUser([FromBody] LoginRequest request)
        {
            Result result = _service.SignInUser(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
            
        }
        [HttpPost("/request-reset")]
        public IActionResult RequestPasswordReset(RequestPasswordReset request)
        {
            Result result = _service.RequestPasswordReset(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }
        [HttpPost("/proceed-reset")]
        public IActionResult ProceedPasswordReset(ProceedResetRequest request)
        {
            Result result = _service.ProceedPasswordReset(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
