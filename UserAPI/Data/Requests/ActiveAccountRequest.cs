using System.ComponentModel.DataAnnotations;

namespace UserAPI.Requests
{
    public class ActiveAccountRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string ActivationCode { get; set; }  
    }
}
