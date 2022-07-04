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
    public class TheaterService
    {
        private AppDbContext _context;

        private IMapper _mapper; 

        public TheaterService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTheaterDTO AddTheater(CreateTheaterDTO theaterDto)
        {
            Theater theater = _mapper.Map<Theater>(theaterDto);
            _context.Theaters.Add(theater);
            _context.SaveChanges();
            return _mapper.Map<ReadTheaterDTO>(theater);

        }

        public List<ReadTheaterDTO> GetAllTheaters(string TheaterName)
        {
            List<Theater> theaters = _context.Theaters.ToList();
            if (theaters == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(TheaterName))
            {
                IEnumerable<Theater> query = from theater in theaters
                                             where theater.Sessions.Any(
                                                 session => session.Theater.Name == TheaterName)
                                             select theater;

                theaters = query.ToList();
            }
            List<ReadTheaterDTO> readDto = _mapper.Map<List<ReadTheaterDTO>>(theaters);
            return readDto;
        }

        public ReadTheaterDTO GetTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater != null)
            {
                ReadTheaterDTO movieDTO = _mapper.Map<ReadTheaterDTO>(theater);
                return movieDTO;
            }
            return null;
        }

        public Result PutTheater(int id, UpdateTheaterDTO theaterDto)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater == null)
            {
                return Result.Fail("Theater not found");
            }
            _mapper.Map(theaterDto, theater);
            _context.SaveChanges();
            return Result.Ok();
        }
        public Result DeleteTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater == null)
            {
                return Result.Fail("Theater not found");
            }
            _context.Remove(theater);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
