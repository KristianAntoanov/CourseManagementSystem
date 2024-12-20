using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Models;

[PrimaryKey(nameof(StudentId), nameof(CourseId))]
public class StudentCourse
{
    public Guid StudentId { get; set; }

    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; } = null!;

    public Guid CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CompletedOn { get; set; }

    public decimal Progress { get; set; }
}