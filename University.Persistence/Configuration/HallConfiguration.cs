using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Cinema.Models;

namespace Cinema.Persistence.Configuration;

public class HallConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.HasKey(hall => hall.Id);

        builder.Property(hall => hall.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(hall => hall.Seats)
            .IsRequired();

        builder.HasOne(hall => hall.Building)
            .WithMany(building => building.Halls)
            .HasForeignKey(hall => hall.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}