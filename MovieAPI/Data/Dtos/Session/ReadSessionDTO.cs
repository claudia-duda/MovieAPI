using MovieAPI.Models;
using System;

namespace MovieAPI.Data.Dtos
{
    public class ReadSessionDTO
    {
        public int Id { get; set; }
        public Theater Theater { get; set; }
        public Movie Movie { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set;}

       
    }
}
