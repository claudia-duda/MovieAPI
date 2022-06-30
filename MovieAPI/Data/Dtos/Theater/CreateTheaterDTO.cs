using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data.Dtos
{
    public class CreateTheaterDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
