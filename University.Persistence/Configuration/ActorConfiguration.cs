using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Cinema.Models;

namespace Cinema.Persistence.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(actor => actor.Id);

            builder.Property(actor => actor.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(actor => actor.LastName).HasMaxLength(100).IsRequired();

            builder.HasMany(actor => actor.Movies)
                .WithMany(movie => movie.Actors);
        }
    }
}
