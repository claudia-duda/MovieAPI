using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDTO, Session>();
            CreateMap<Session, ReadSessionDTO>()
                .ForMember(dto => dto.StartTime, opts => opts
                .MapFrom(dto => dto.EndTime.AddMinutes(dto.Movie.Duration * (-1))));
        }
    }
}
