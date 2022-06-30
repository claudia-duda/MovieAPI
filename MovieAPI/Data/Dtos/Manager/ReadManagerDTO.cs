using MovieAPI.Models;
using System.Collections.Generic;

namespace MovieAPI.Data.Dtos
{
    public class ReadManagerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Theaters { get; set; }

    }
}
