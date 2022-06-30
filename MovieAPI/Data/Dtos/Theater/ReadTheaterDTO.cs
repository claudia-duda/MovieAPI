using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Data.Dtos
{
    public class ReadTheaterDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field Name is required")]
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
