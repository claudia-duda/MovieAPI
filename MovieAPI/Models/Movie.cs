using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }
        [StringLength(30,ErrorMessage = "The lenght of gender have to be until 30")]
        public string Gender { get; set; }
        [Range(1, 300, ErrorMessage = "Duration have ot be into 1 and 120")]
        public int Duration { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }
    }
}
