namespace CourseManagement.WebApi.IOModels.StudentCourse;

public class StudentCourseOutputModel
{
    public Guid CourseId { get; set; }

    public string CourseTitle { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public decimal Progress { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedOn { get; set; }
}