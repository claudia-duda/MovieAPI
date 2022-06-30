using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data.Dtos
{
    public class CreateAddressDTO
    {
        public string Street { get; set; }
        public string Region { get; set; }
        public int Number { get; set; }

    }
}
