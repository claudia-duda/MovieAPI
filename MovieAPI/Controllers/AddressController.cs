using AutoMapper;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAddress([FromBody] CreateAddressDTO addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaAddresssPorId), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<Address> RecuperaAddresss()
        {
            return _context.Addresses;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAddresssPorId(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDTO addressDto = _mapper.Map<ReadAddressDTO>(address);

                return Ok(addressDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAddress(int id, [FromBody] UpdateAddressDTO addressDto)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}