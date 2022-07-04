using AutoMapper;
using FluentResults;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Services
{
    public class AddressService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public AddressService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadAddressDTO AddAddress(CreateAddressDTO addressDto)
        {

            Address address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return _mapper.Map<ReadAddressDTO>(address);
        }

        public List<ReadAddressDTO> GetAddresses()
        {
            List<Address> addresses = _context.Addresses.ToList();

            if (addresses != null)
            {
                List<ReadAddressDTO> readDto = _mapper.Map<List<ReadAddressDTO>>(addresses);
                return readDto;
            }
            return null;
        }

        public ReadAddressDTO GetAddresses(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                return _mapper.Map<ReadAddressDTO>(address);
            }
            return null;
        }

        public Result PutAddress(int id, UpdateAddressDTO addressDto)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
              return Result.Fail("Address not found");
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return Result.Fail("Address not found");
            }
            _context.Remove(address);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
