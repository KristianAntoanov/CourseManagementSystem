using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.StudentCourse;
using MediatR;

namespace CourseManagement.Application.StudentCourse.Query;

public class GetCompletedCoursesQuery : IRequest<IEnumerable<StudentCourseOutputModel>>
{
    public Guid StudentId { get; set; }
}

public class GetCompletedCoursesQueryHandler
    : IRequestHandler<GetCompletedCoursesQuery, IEnumerable<StudentCourseOutputModel>>
{
    private readonly IEnrollmentService _enrollmentService;

    public GetCompletedCoursesQueryHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<IEnumerable<StudentCourseOutputModel>> Handle(
        GetCompletedCoursesQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.GetCompletedCoursesAsync(request.StudentId);
    }
}