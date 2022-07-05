using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Requests;

namespace UserAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result SignInUser(LoginRequest request)
        {
            var resultIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(
                        user =>
                            user.NormalizedUserName == request.Username.ToUpper()
                    );

               Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);

            }
            return Result.Fail("Sign in has failed");
        }
    }
}
