using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Dtos
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string RePassword { get; set; }  
    }
}
