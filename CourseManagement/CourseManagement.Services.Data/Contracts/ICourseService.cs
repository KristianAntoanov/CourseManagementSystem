using CourseManagement.WebApi.IOModels.Course;

namespace CourseManagement.Services.Data.Contracts;

public interface ICourseService
{
    Task<bool> AddCourseAsync(CourseInputModel model);

    Task<IEnumerable<CourseOutputModel>> GetAllAvailableCoursesAsync();

    Task<bool> UpdateCourseAsync(CourseUpdateInputModel model);

    Task<bool> RemoveCourseAsync(Guid id);
}