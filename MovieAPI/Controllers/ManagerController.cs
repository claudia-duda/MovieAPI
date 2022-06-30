using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult PostManager(CreateManagerDTO managerdto)
        {
            Manager manager = _mapper.Map<Manager>(managerdto);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetManager), new { Id = manager.Id }, manager);
        }
        [HttpGet("{id}")]
        public IActionResult GetManager(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ReadManagerDTO managerDto = _mapper.Map<ReadManagerDTO>(manager);

                return Ok(managerDto);
            }
            return NotFound();
        }
    }
}
