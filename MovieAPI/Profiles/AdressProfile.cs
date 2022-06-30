using AutoMapper;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Data.Dtos;

namespace MovieAPI.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();
        }
    }
}
