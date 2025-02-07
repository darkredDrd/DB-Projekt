using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cinema.Models;

namespace Cinema.Persistence.Configuration;

public class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
{
    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        builder.HasKey(revenue => revenue.Id);

        builder.HasOne(revenue => revenue.Screening)
            .WithOne(screening => screening.Revenue)
            .HasForeignKey("ScreeningId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(revenue => revenue.TotalRevenue)
            .IsRequired();
    }
}

