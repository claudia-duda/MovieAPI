using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Theater Theater { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime EndTime { get; set; }

    }
}
