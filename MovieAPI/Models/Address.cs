using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public int Number { get; set; }
        public Theater Theater { get; set; }
        
    }
}
