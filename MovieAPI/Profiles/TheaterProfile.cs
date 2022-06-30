using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<CreateTheaterDTO, Theater>();
            CreateMap<Theater, ReadTheaterDTO>();
            CreateMap<UpdateTheaterDTO, Theater>();
        }
    }
}
