using Core.DataAccess.Entities;

namespace MovieProject.Model.Entities;

public sealed class Category : Entity<int>
{

    public Category()
    {
        Name = string.Empty;
        Movies = new List<Movie>();
    }
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}





