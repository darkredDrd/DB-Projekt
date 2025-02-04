using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cinema.Models;

namespace Cinema.Persistence.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(movie => movie.Id);

        builder.Property(movie => movie.Title).HasMaxLength(200).IsRequired();
        builder.Property(movie => movie.Genre).HasMaxLength(100).IsRequired();
        builder.Property(movie => movie.ReleaseDate).IsRequired();
        builder.Property(movie => movie.Director).HasMaxLength(100).IsRequired();

        builder.HasMany(movie => movie.Actors)
            .WithMany(actor => actor.Movies);
    }
}