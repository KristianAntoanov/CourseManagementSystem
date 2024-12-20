using System.ComponentModel.DataAnnotations;

using static CourseManagement.Common.ValidationConstants.Student;

namespace CourseManagement.Data.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(NameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(NameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(EmailMaxLength)]
    public string Email { get; set; } = null!;

    public int CompletedCourses { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
        = new HashSet<StudentCourse>();
}