using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Model.Dtos.Artists;
using MovieProject.Model.Dtos.Movies;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;

namespace MovieProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController(IArtistService artistService) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(ArtistAddRequestDto dto) =>
            Ok(await artistService.AddAsync(dto));

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateAsync(ArtistUpdateRequestDto dto) =>
            Ok(await artistService.UpdateAsync(dto));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(long id) => 
            Ok(await artistService.DeleteAsync(id));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync() => Ok(await artistService.GetAllAsync());

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id) => Ok(await artistService.GetByIdAsync(id));

        [HttpGet("GetAllByMovieId")]
        public async Task<IActionResult> GetAllByMovieId(Guid id) => Ok(await artistService.GetAllByMovieIdAsync(id));

    }
}
