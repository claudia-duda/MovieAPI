using AutoMapper;
using MovieAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;
using System.Collections.Generic;
using System.Linq;
using MovieAPI.Services;
using FluentResults;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheaterController : ControllerBase
    {
        private TheaterService _service;

        public TheaterController(TheaterService service)
        {
            _service = service;
        }
  

        [HttpPost]
        public IActionResult PostTheater([FromBody] CreateTheaterDTO Theater)
        {
            ReadTheaterDTO theaterDto = _service.AddTheater(Theater);
            return CreatedAtAction(nameof(GetTheater), new { Id = theaterDto.Id }, theaterDto);
        }

        [HttpGet]
        public IActionResult GetAllTheaters([FromQuery] string theaterName)
        {
            List<ReadTheaterDTO> theatersDto = _service.GetAllTheaters(theaterName);
            if (theatersDto != null) return Ok(theatersDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetTheater(int id)
        {
            ReadTheaterDTO theaterDto = _service.GetTheater(id);

            if (theaterDto != null) return Ok(theaterDto);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutTheater(int id, [FromBody] UpdateTheaterDTO theaterDto)
        {
            Result result = _service.PutTheater(id, theaterDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            Result result = _service.DeleteTheater(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
