﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using University.Models;

namespace University.Persistence.Configuration;

public class MarkConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.HasKey(course => course.Id);

        builder.HasOne(mark => mark.Student)
            .WithMany(student => student.Marks);

        builder.HasOne(mark => mark.Course)
            .WithMany(course => course.Marks);

        builder.HasOne(mark => mark.Teacher)
            .WithMany(teacher => teacher.Marks);
    }
}