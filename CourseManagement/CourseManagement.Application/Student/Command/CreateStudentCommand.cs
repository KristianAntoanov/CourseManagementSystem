using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Student;

using MediatR;

namespace CourseManagement.Application.Student.Command;

public class CreateStudentCommand : StudentInputModel, IRequest<bool>
{
    public string Id { get; set; } = null!;
}

public class CreateStudentCommandHandler :
    IRequestHandler<CreateStudentCommand, bool>
{
    private readonly IStudentService _studentService;

    public CreateStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<bool> Handle(
        CreateStudentCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _studentService.AddStudentAsync(request);
    }
}