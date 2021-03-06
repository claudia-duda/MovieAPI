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
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public RegistrationService(IMapper mapper,
            UserManager<CustomIdentityUser> userManager,
            EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result AddUser(CreateUserDTO createDto)
        {
            User user = _mapper.Map<User>(createDto);
            CustomIdentityUser userIdentity = _mapper.Map<CustomIdentityUser>(user);

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
