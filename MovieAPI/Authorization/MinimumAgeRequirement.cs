using Microsoft.AspNetCore.Authorization;

namespace MovieAPI.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }

        public MinimumAgeRequirement(int age)
        {
            Age = age;
        }
    }
}
