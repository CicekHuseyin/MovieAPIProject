using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MovieId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();

        builder
            .HasOne(x => x.Director)
            .WithMany(x => x.Movies)
            .HasForeignKey(z => z.DirectorId);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Movies)
            .HasForeignKey(z => z.CategoryId);

        builder
            .HasMany(x => x.MovieArtists)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.Navigation(x => x.Director).AutoInclude();
        builder.Navigation(x => x.Category).AutoInclude();
    }
}
