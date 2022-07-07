using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieAPI.Authorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask;

            DateTime birthDate = Convert.ToDateTime(context.User
                .FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            int ageGet = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-ageGet))//compare the month and day
                ageGet--;
            if (ageGet >= requirement.Age) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
