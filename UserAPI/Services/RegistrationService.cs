using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserAPI.Data.Dtos;
using UserAPI.Models;
using UserAPI.Requests;

namespace UserAPI.Services
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public RegistrationService(IMapper mapper,
            UserManager<IdentityUser<int>> userManager,
            EmailService emailService,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result AddUser(CreateUserDTO createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            Task<IdentityResult> resultIdentity = _userManager
                .CreateAsync(userIdentity , createDto.Password);
            
            if (resultIdentity.Result.Succeeded)
            {
                _userManager.AddToRoleAsync(userIdentity, "regular");
                string code = _userManager
                    .GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.SendEmail(new[] { userIdentity.Email}, 
                    "Link of confirmation", userIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(code).WithSuccess(code);

            }
            return Result.Fail("Action of registration has failed");
        }

        public Result ActiveAccountRequest(ActiveAccountRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(user => user.Id == request.AccountId);

            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.ActivationCode).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Failed on account activation");
        }
    }
}
