using AutoMapper;
using FluentResults;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Linq;

namespace MovieAPI.Services
{
    public class ManagerService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public ManagerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadManagerDTO AddManager(CreateManagerDTO managerDto)
        {
            Manager manager = _mapper.Map<Manager>(managerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return _mapper.Map<ReadManagerDTO>(manager);
        }

        public ReadManagerDTO GetManager(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ReadManagerDTO managerDto = _mapper.Map<ReadManagerDTO>(manager);
                return managerDto;
            }
            return null;
        }

        public Result DeleteManager(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager == null)
            {
                return Result.Fail("Manager not found");
            }
            _context.Remove(manager);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
