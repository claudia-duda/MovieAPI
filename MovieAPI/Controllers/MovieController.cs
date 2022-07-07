using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using MovieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieService _service;
        public MovieController(MovieService movieService)
        {
            _service = movieService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult PostMovie([FromBody] CreateMovieDTO movieDto)
        {
            ReadMovieDTO readDto = _service.AddMovie(movieDto);
           
            return CreatedAtAction(nameof(GetMovie), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetMovies([FromQuery] int? classification)
        {
            List<ReadMovieDTO> moviesDTO =_service.GetMovies(classification);
            
            if(moviesDTO != null)return Ok(moviesDTO);
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            ReadMovieDTO movieDTO = _service.GetMovie(id);

            if (movieDTO != null) return Ok(movieDTO);
            return NotFound();
            
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, UpdateMovieDTO movieDto)
        {
            Result result =_service.PutMovie(id, movieDto);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Result result = _service.DeleteMovie(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
