using CourseManagement.WebApi.IOModels.Student;

namespace CourseManagement.Services.Data.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentOutputModel>> GetAllStudentsAsync();

    Task<bool> AddStudentAsync(StudentInputModel model);

    Task<bool> UpdateStudentAsync(StudentUpdateInputModel model);

    Task<bool> RemoveStudentAsync(Guid id);
}