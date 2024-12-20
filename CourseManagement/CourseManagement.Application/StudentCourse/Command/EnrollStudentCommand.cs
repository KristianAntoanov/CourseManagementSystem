using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.StudentCourse;

using MediatR;

namespace CourseManagement.Application.StudentCourse.Command;

public class EnrollStudentCommand : EnrollStudentInputModel, IRequest<bool>
{
}

public class EnrollStudentCommandHandler : IRequestHandler<EnrollStudentCommand, bool>
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollStudentCommandHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<bool> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.EnrollStudentInCourseAsync(request.StudentId, request.CourseId);
    }
}