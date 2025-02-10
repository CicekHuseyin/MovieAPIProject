using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddAsync(MovieAddRequestDto dto)
        {
            var result = await _movieService.AddAsync(dto);

            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _movieService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetAllByCategoryId")]
        public async Task<IActionResult> GetAllByCategoryIdAsync(int categoryId)
        {
            var result = await _movieService.GetAllByCategoryIdAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("GetAllByDirectorId")]
        public async Task<IActionResult> GetAllByDirectorIdAsync(long directorId)
        {
            var result = await _movieService.GetAllByDirectorIdAsync(directorId);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(MovieUpdateRequestDto dto)
        {
            await _movieService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _movieService.GetByIdAsync(id));

        [HttpGet("ImdbRange")]
        public async Task<IActionResult> GetAllByImdbRangeAsync(double min, double max)
            => Ok(_movieService.GetAllByImdbRangeAsync(min, max));
    }
}
