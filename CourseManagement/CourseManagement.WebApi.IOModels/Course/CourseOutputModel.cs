namespace CourseManagement.WebApi.IOModels.Course;

public class CourseOutputModel
{
	public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}