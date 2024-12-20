using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Course;

using MediatR;

namespace CourseManagement.Application.Course.Command;

public class UpdateCourseCommand : CourseUpdateInputModel, IRequest<bool>
{
}

public class UpdateCourseCommandHandler :
    IRequestHandler<UpdateCourseCommand, bool>
{
    private readonly ICourseService _courseService;

    public UpdateCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<bool> Handle(
        UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _courseService.UpdateCourseAsync(request);
    }
}