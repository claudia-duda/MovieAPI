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
    public class MovieService
    {
        private AppDbContext _context;

        private IMapper _mapper; 

        public MovieService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadMovieDTO AddMovie(CreateMovieDTO movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return _mapper.Map<ReadMovieDTO>(movie);

        }

        public List<ReadMovieDTO> GetMovies(int? classification)
        {
            List<Movie> movies;
            if (classification == null)
            {
                movies = _context.Movies.ToList();
            }
            else
            {
                movies = _context.Movies
                    .Where(movie => movie.Classification <= classification).ToList();
            }
            if (movies != null)
            {
                List<ReadMovieDTO> readDto = _mapper.Map<List<ReadMovieDTO>>(movies);
                return readDto;
            }
            return null;
        }

        public ReadMovieDTO GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);
                return movieDTO;
            }
            return null;
        }

        public Result PutMovie(int id, UpdateMovieDTO movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return Result.Fail("Movie not found");
            }
            _mapper.Map(movieDto, movie);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return Result.Fail("Movie not found");
            }
            _context.Remove(movie); //_context.Movies.Remove(movie)

            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
