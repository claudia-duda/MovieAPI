using Microsoft.AspNetCore.Identity;
using System;

namespace UserAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
    }
}
