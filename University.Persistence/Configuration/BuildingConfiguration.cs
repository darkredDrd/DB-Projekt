using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Cinema.Models;

namespace Cinema.Persistence.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(building => building.Id);

            builder.Property(building => building.Name).HasMaxLength(100).IsRequired();


        }
    }
}
