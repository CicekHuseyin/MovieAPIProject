using Microsoft.AspNetCore.Http;
using MovieProject.Model.Dtos.Categories;
using MovieProject.Model.Dtos.Movies;

namespace MovieProject.Service.Abstracts;

public interface IMovieService
{
    string Add(MovieAddRequestDto dto);
    void Update(MovieUpdateRequestDto dto);
    void Delete(Guid id);
    List<MovieResponseDto> GetAll();
    MovieResponseDto? GetById(Guid id);
    List<MovieResponseDto> GetAllByCategoryId(int id);
    List<MovieResponseDto> GetAllByDirectorId(long id);
    List<MovieResponseDto?> GetAllByImdbResponse(double min, double max);
    List<MovieResponseDto?> GetAllByIsActive(bool active);
}
