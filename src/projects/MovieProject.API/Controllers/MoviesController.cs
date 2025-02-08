﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Model.Dtos.Movies;
using MovieProject.Service.Abstracts;

namespace MovieProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost("Add")]
        public IActionResult Add(MovieAddRequestDto dto)
        {
            var result = _movieService.Add(dto);

            return Ok(result);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            return Ok(result);
        }
    }
}
