using AutoMapper;
using MovieAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheaterController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TheaterController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
  

        [HttpPost]
        public IActionResult PostTheater([FromBody] CreateTheaterDTO Theater)
        {
            Theater theater = _mapper.Map<Theater>(Theater);
            _context.Theaters.Add(theater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTheater), new { Id = theater.Id }, theater);
        }

        [HttpGet]
        public IActionResult GetAllTheaters([FromQuery] string MovieName)
        {
            List<Theater> theaters = _context.Theaters.ToList();
            if(theaters == null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(MovieName))
            {
                IEnumerable<Theater> query = from theater in theaters
                        where theater.Sessions.Any(
                            session => session.Movie.Title == MovieName)
                        select theater;

                theaters = query.ToList();
            }
            List<ReadTheaterDTO> readDto = _mapper.Map<List<ReadTheaterDTO>>(theaters);
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult GetTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if(theater != null)
            {
                ReadTheaterDTO theaterDto = _mapper.Map<ReadTheaterDTO>(theater);
                return Ok(theaterDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutTheater(int id, [FromBody] UpdateTheaterDTO theaterDto)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if(theater == null)
            {
                return NotFound();
            }
            _mapper.Map(theaterDto, theater);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater == null)
            {
                return NotFound();
            }
            _context.Remove(theater);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
