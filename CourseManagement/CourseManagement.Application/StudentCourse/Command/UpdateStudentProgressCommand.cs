using CourseManagement.Services.Data.Contracts;

using MediatR;

namespace CourseManagement.Application.StudentCourse.Command;

public class UpdateStudentProgressCommand : IRequest<bool>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public decimal Progress { get; set; }
}

public class UpdateStudentProgressCommandHandler : IRequestHandler<UpdateStudentProgressCommand, bool>
{
    private readonly IEnrollmentService _enrollmentService;

    public UpdateStudentProgressCommandHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<bool> Handle(
        UpdateStudentProgressCommand request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        if (request.Progress < 0 || request.Progress > 100)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.UpdateStudentProgressAsync(
            request.StudentId,
            request.CourseId,
            request.Progress);
    }
}