using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using University.Models;

namespace University.Persistence.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(s => s.LastName).HasMaxLength(100).IsRequired();

            builder.Property(s => s.Phone).HasMaxLength(15);

            builder.Property(s => s.Email).HasMaxLength(200).IsRequired();
            builder.Property(s => s.PassportNumber).HasMaxLength(15).IsRequired();
        }
    }
}
