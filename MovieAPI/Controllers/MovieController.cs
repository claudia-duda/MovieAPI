using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }
       
        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
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
                return Ok(movie);
            }
            return NotFound();
            
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie newMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            movie.Title = newMovie.Title;
            movie.Director = newMovie.Director;
            movie.Duration = newMovie.Duration;
            movie.Gender = newMovie.Gender;

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
