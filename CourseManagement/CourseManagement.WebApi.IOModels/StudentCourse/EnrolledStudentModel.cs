namespace CourseManagement.WebApi.IOModels.StudentCourse;

public class EnrolledStudentModel
{
    public Guid StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public decimal Progress { get; set; }
}