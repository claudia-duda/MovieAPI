using AutoMapper;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Services;
using FluentResults;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostAddress([FromBody] CreateAddressDTO addressDto)
        {
            ReadAddressDTO address = _service.AddAddress(addressDto);
  
            return CreatedAtAction(nameof(GetAddress), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            List<ReadAddressDTO> addressesDTO = _service.GetAddresses();
            if (addressesDTO != null) return Ok(addressesDTO);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(int id)
        {
            ReadAddressDTO addressDTO = _service.GetAddresses(id);
            if (addressDTO != null) return Ok(addressDTO);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutAddress(int id, [FromBody] UpdateAddressDTO addressDto)
        {
            Result result = _service.PutAddress(id, addressDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Result result = _service.DeleteAddress(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}