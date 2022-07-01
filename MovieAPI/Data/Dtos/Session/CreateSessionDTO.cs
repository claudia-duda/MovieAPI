using System;

namespace MovieAPI.Data.Dtos
{
    public class CreateSessionDTO
    {
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime EndTime { get; set; }
    }
}
