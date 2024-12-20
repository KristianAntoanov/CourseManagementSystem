using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Student;

using MediatR;

namespace CourseManagement.Application.Student.Query;

public class GetStudentsQuery : IRequest<IEnumerable<StudentOutputModel>>
{
}

public class GetStudentsQueryHandler :
    IRequestHandler<GetStudentsQuery, IEnumerable<StudentOutputModel>>
{
    private readonly IStudentService _studentService;

    public GetStudentsQueryHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IEnumerable<StudentOutputModel>> Handle(
        GetStudentsQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _studentService.GetAllStudentsAsync();
    }
}