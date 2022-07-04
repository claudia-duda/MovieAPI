using AutoMapper;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Linq;

namespace MovieAPI.Services
{
    public class SessionService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public SessionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadSessionDTO AddSession(CreateSessionDTO dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();

            return _mapper.Map<ReadSessionDTO>(session);
        }

        public ReadSessionDTO GetSession(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                ReadSessionDTO managerDto = _mapper.Map<ReadSessionDTO>(session);

                return managerDto;
            }
            return null;
        }
    }
}
