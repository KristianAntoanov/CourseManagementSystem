using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Course;

using MediatR;

namespace CourseManagement.Application.Course.Query;

public class GetAvailableCoursesQuery : IRequest<IEnumerable<CourseOutputModel>>
{
}

public class GetAvailableCoursesQueryHandler :
    IRequestHandler<GetAvailableCoursesQuery, IEnumerable<CourseOutputModel>>
{
    private readonly ICourseService _courseService;

    public GetAvailableCoursesQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IEnumerable<CourseOutputModel>> Handle(
        GetAvailableCoursesQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _courseService.GetAllAvailableCoursesAsync();
    }
}