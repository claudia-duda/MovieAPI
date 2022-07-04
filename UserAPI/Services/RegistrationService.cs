using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UserAPI.Data.Dtos;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        public RegistrationService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result AddUser(CreateUserDTO createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity , createDto.Password);
           
            if(resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Action of registration has failed");
        }
    }
}
