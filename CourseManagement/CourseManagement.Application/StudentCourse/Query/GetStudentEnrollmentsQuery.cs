using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.StudentCourse;

using MediatR;

namespace CourseManagement.Application.StudentCourse.Query;

public class GetStudentEnrollmentsQuery : IRequest<IEnumerable<StudentCourseOutputModel>>
{
    public Guid StudentId { get; set; }
}

public class GetStudentEnrollmentsQueryHandler :
    IRequestHandler<GetStudentEnrollmentsQuery, IEnumerable<StudentCourseOutputModel>>
{
    private readonly IEnrollmentService _enrollmentService;

    public GetStudentEnrollmentsQueryHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<IEnumerable<StudentCourseOutputModel>> Handle(
        GetStudentEnrollmentsQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.GetStudentEnrollmentsAsync(request.StudentId);
    }
}