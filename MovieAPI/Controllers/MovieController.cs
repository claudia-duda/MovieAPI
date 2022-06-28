﻿using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using System.Collections.Generic;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies= new List<Movie>();

        [HttpPost]
        public void PostMovie(Movie movie)
        {
            movies.Add(movie);
        }
       
    }
}
