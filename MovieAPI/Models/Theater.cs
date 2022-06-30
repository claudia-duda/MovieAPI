using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Theater
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field Name is required")]
        public string Name { get; set; }

    }
}
