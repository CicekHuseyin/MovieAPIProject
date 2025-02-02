using Core.DataAccess.Entities;

namespace MovieProject.Model.Entities;

public sealed class Director : Entity<long>
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string ImageUrl { get; set; }

    public DateTime BirthDay { get; set; }


    public ICollection<Movie> Movies { get; set; }
}





