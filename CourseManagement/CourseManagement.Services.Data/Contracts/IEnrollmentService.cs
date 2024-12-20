using CourseManagement.WebApi.IOModels.StudentCourse;

namespace CourseManagement.Services.Data.Contracts;

public interface IEnrollmentService
{
    Task<IEnumerable<StudentCourseOutputModel>> GetStudentEnrollmentsAsync(Guid studentId);

    Task<CourseWithEnrolledStudentsOutputModel> GetCourseWithEnrolledStudentsAsync(Guid courseId);

    Task<bool> EnrollStudentInCourseAsync(Guid studentId, Guid courseId);

    Task<bool> UpdateStudentProgressAsync(Guid studentId, Guid courseId, decimal progress);

    Task<bool> CompleteCourseAsync(Guid studentId, Guid courseId);

    Task<IEnumerable<StudentCourseOutputModel>> GetCompletedCoursesAsync(Guid studentId);
}