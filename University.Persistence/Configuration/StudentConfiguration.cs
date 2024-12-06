using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using University.Models;

namespace University.Persistence.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);

            builder.Property(student => student.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(student => student.LastName).HasMaxLength(100).IsRequired();

            builder.Property(student => student.Phone).HasMaxLength(15);

            builder.Property(student => student.Email).HasMaxLength(200).IsRequired();
            builder.Property(student => student.PassportNumber).HasMaxLength(15).IsRequired();

            builder.HasMany(student => student.Courses)
                .WithMany(course => course.Students);
        }
    }
}
