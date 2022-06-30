using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<Movie, ReadMovieDTO>();
            CreateMap<UpdateMovieDTO, Movie>();
        }
    }
}
