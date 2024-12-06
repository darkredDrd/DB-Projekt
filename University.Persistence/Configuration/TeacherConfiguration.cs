using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using University.Models;

namespace University.Persistence.Configuration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(teacher => teacher.Id);

        builder.Property(teacher => teacher.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(teacher => teacher.LastName).HasMaxLength(100).IsRequired();

        builder.Property(teacher => teacher.Phone).HasMaxLength(15);

        builder.Property(teacher => teacher.Email).HasMaxLength(200).IsRequired();
        builder.Property(teacher => teacher.PassportNumber).HasMaxLength(15).IsRequired();

        builder.HasMany(student => student.Courses)
            .WithMany(course => course.Teachers);
    }
}