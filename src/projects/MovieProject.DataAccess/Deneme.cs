using MovieProject.Model.Entities;

namespace MovieProject.DataAccess;

public class Deneme
{
    public void Dene()
    {
        Movie movie = new Movie()
        {
            Id = Guid.NewGuid(),
            CategoryId = 1,
            CreatedTime = DateTime.Now
        };
    }
}
