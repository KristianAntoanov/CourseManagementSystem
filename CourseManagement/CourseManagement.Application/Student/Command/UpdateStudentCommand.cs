using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Student;

using MediatR;

namespace CourseManagement.Application.Student.Command;

public class UpdateStudentCommand : StudentUpdateInputModel, IRequest<bool>
{
}

public class UpdateStudentCommandHandler :
    IRequestHandler<UpdateStudentCommand, bool>
{
    private readonly IStudentService _studentService;

    public UpdateStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<bool> Handle(
        UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _studentService.UpdateStudentAsync(request);
    }
}