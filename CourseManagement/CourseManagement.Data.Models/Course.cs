using System.ComponentModel.DataAnnotations;

using static CourseManagement.Common.ValidationConstants.Course;

namespace CourseManagement.Data.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    public int MaxStudents { get; set; }

    public int CurrentStudentsCount { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
        = new HashSet<StudentCourse>();
}