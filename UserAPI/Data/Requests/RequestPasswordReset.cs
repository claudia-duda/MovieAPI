using System.ComponentModel.DataAnnotations;

namespace UserAPI.Requests
{
    public class RequestPasswordReset
    {
        [Required]
        public string Email { get; set; }
    }
}
