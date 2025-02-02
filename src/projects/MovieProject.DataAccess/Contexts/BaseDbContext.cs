using Microsoft.EntityFrameworkCore;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Contexts;

public sealed class BaseDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-KR485FT\SQLEXPRESS; Database=MovieProjectDb; user=sa; password=5665; TrustServerCertificate=true");
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieArtist> MovieArtists { get; set; }
}
