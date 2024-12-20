using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CourseManagement.Data.Models;

namespace CourseManagement.Data.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasMany(s => s.StudentCourses)
               .WithOne(sc => sc.Student)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.CompletedCourses)
               .HasDefaultValue(0);

        builder.Property(c => c.IsDeleted)
               .HasDefaultValue(false);
    }
}