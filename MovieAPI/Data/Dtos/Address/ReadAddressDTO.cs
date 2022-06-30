using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Data.Dtos
{
    public class ReadAddressDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public int Number { get; set; }

    }
}
