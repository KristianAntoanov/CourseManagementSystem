using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.StudentCourse;
using MediatR;

namespace CourseManagement.Application.StudentCourse.Query;

public class GetCourseWithEnrolledStudentsQuery : IRequest<CourseWithEnrolledStudentsOutputModel>
{
    public Guid CourseId { get; set; }
}

public class GetCourseWithEnrolledStudentsQueryHandler :
    IRequestHandler<GetCourseWithEnrolledStudentsQuery, CourseWithEnrolledStudentsOutputModel>
{
    private readonly IEnrollmentService _enrollmentService;

    public GetCourseWithEnrolledStudentsQueryHandler(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<CourseWithEnrolledStudentsOutputModel> Handle(
        GetCourseWithEnrolledStudentsQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _enrollmentService.GetCourseWithEnrolledStudentsAsync(request.CourseId);
    }
}