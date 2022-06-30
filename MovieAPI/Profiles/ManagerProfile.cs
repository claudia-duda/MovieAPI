using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System.Linq;

namespace MovieAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDTO, Manager>();
            CreateMap<Manager, ReadManagerDTO>()
                .ForMember(
                    manager =>manager.Theaters,
                        options => options.MapFrom(
                            manager => manager.Theaters.Select(
                            t =>
                                new {t.Id, t.Name, t.Address}
                        ))
                );
        }
    }
}
