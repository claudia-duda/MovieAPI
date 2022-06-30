using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        private IMapper _mapper;
        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        [HttpPost]
        public IActionResult PostMovie([FromBody] CreateMovieDTO movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movie);
        }
        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
          Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);
                return Ok(movieDTO);
            }
            return NotFound();
            
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, UpdateMovieDTO movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDto, movie);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie); //_context.Movies.Remove(movie)

            _context.SaveChanges();
            return NoContent();
        }
    }
}
