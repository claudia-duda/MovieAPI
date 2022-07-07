using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Data.Requests;
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

               Token token = _tokenService
                    .CreateToken(identityUser, _signInManager
                        .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);

            }
            return Result.Fail("Sign in has failed");
        }

        public Result RequestPasswordReset(RequestPasswordReset request)
        {
            IdentityUser<int> identityUser = RecoverUserByEmail(request.Email);
            if (identityUser != null)
            {
                string codeRecovery = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codeRecovery);
            }
            return Result.Fail("Failed on request the password reset");
        }

        public Result ProceedPasswordReset(ProceedResetRequest request)
        {
            IdentityUser<int> identityUser = RecoverUserByEmail(request.Email);
            IdentityResult identityResult = _signInManager
                .UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;

            if (identityResult.Succeeded) return Result.Ok()
                    .WithSuccess("Password was changed sucessfuly");
            return Result.Fail("There was an error");
        }

        private IdentityUser<int> RecoverUserByEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }
    }
}
