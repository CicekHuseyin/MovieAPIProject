using MovieProject.Model.Dtos.Categories;

namespace MovieProject.Service.Abstracts;

public interface ICategoryService
{
    void Add(CategoryAddRequestDto dto);
    void Update(CategoryUpdateRequestDto dto);
    void Delete(int id);
    List<CategoryResponseDto> GetAll();
    CategoryResponseDto? GetById(int id);
}
