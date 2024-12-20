using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CourseManagement.Data.Models;

namespace CourseManagement.Data.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.CurrentStudentsCount)
               .HasDefaultValue(0);

        builder.Property(c => c.MaxStudents)
               .HasDefaultValue(500);

        builder.Property(c => c.IsAvailable)
               .HasDefaultValue(true);

        builder.Property(c => c.IsDeleted)
               .HasDefaultValue(false);

        builder.HasMany(c => c.StudentCourses)
               .WithOne(sc => sc.Course)
               .OnDelete(DeleteBehavior.Restrict);
    }
}