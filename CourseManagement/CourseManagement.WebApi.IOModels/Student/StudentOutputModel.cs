namespace CourseManagement.WebApi.IOModels.Student;

public class StudentOutputModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CompletedCourses { get; set; }
}