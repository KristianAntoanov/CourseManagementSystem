using CourseManagement.Services.Data.Contracts;

using MediatR;

namespace CourseManagement.Application.Student.Command;

public class RemoveStudentCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, bool>
{
    private readonly IStudentService _studentService;

    public RemoveStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<bool> Handle(
        RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _studentService.RemoveStudentAsync(request.Id);
    }
}