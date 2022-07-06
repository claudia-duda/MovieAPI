using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserAPI.Data.Dtos;
using UserAPI.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService _service;

        public RegistrationController(RegistrationService service)
        {
            _service = service;
        }   

        [HttpPost]
        public IActionResult PostUser(CreateUserDTO createDto)
        {
            Result result = _service.AddUser(createDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes.FirstOrDefault());
        }
        [HttpGet("confirmation")]
        public IActionResult ActiveUserAccount([FromQuery] ActiveAccountRequest request)
        {
            Result result = _service.ActiveAccountRequest(request);
            if(result.IsFailed) return StatusCode(500);
            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
