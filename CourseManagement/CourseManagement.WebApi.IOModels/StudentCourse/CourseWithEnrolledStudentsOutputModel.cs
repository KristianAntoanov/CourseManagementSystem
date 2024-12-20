namespace CourseManagement.WebApi.IOModels.StudentCourse;

public class CourseWithEnrolledStudentsOutputModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public IEnumerable<EnrolledStudentModel> EnrolledStudents { get; set; }
        = new HashSet<EnrolledStudentModel>();
}