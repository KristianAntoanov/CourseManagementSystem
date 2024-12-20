using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CourseManagement.Data.Models;

namespace CourseManagement.Data.Configuration;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.Property(sc => sc.IsCompleted)
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(sc => sc.Progress)
               .HasPrecision(18, 2)
               .HasDefaultValue(0);

        builder.Property(c => c.IsActive)
               .HasDefaultValue(true);
    }
}