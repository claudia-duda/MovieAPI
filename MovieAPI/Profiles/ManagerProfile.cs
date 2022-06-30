using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDTO, Manager>();
            CreateMap<Manager, ReadManagerDTO>();
        }
    }
}
