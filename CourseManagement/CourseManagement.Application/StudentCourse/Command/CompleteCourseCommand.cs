using CourseManagement.Services.Data.Contracts;

using MediatR;

namespace CourseManagement.Application.StudentCourse.Command;

public class CompleteCourseCommand : IRequest<bool>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}

public class CompleteCourseCommandHandler : IRequestHandler<CompleteCourseCommand, bool>
{
    private readonly IEnrollmentService _enrollmentService;

    public CompleteCourseCommandHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<bool> Handle(
        CompleteCourseCommand request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.CompleteCourseAsync(
            request.StudentId,
            request.CourseId);
    }
}