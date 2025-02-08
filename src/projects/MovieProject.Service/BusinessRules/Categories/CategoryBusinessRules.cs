using Core.CrossCuttingConcerns.Exceptions;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Service.Constants.Categories;

namespace MovieProject.Service.BusinessRules.Categories;

//Aynı kategori ismine sahip kategori eklenemez (Kategori adı unique olmalıdır.)
public sealed class CategoryBusinessRules(ICategoryRepository categoryRepository)
{
    public void CategoryIsPresent(int id)
    {
        bool isPresent = categoryRepository.Any(x=>x.Id==id);

        if (!isPresent)
        {
            throw new NotFoundException(CategoryMessages.NotFoundMessage);
        }
    }
    public void CategoryNameMustBeUnique(string name)
    {
        var category = categoryRepository.Any(x => x.Name == name.ToLower());
        if (category)
        {
            throw new BusinessException(CategoryMessages.NameMustBeUnniqueMessage);
        }
    }
}
