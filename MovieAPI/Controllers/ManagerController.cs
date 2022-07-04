using AutoMapper;
using FluentResults;
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
    public class ManagerController : ControllerBase
    {
        private ManagerService _service;

        public ManagerController(ManagerService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostManager(CreateManagerDTO managerDto)
        {
            ReadManagerDTO manager = _service.AddManager(managerDto);
            
            return CreatedAtAction(nameof(GetManager), new { Id = manager.Id }, manager);
        }

        [HttpGet("{id}")]
        public IActionResult GetManager(int id)
        {
            ReadManagerDTO manager = _service.GetManager(id);
            if (manager != null) return Ok(manager);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            Result result = _service.DeleteManager(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
