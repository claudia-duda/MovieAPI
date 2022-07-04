using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using MovieAPI.Services;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController: ControllerBase
    {
        private SessionService _service;
        public SessionController(SessionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostSession(CreateSessionDTO dto)
        {
            ReadSessionDTO session = _service.AddSession(dto);
            return CreatedAtAction(nameof(GetSession), new { Id = session.Id }, session);

        }
        [HttpGet("{id}")]
        public IActionResult GetSession(int id)
        {
            ReadSessionDTO session = _service.GetSession(id);
            if (session != null) return Ok(session);
            return NotFound();
        }

    }
}
