using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Cinema.Models;

namespace Cinema.Persistence.Configuration
{
    public class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            builder.HasKey(screening => screening.Id);

            builder.HasOne(screening => screening.Movie)
                .WithMany()
                .HasForeignKey("MovieId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(screening => screening.Hall)
                .WithMany()
                .HasForeignKey("HallId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(screening => screening.DateTime)
                .IsRequired();
        }
    }
}
