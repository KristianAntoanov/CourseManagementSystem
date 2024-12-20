using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Course;

using MediatR;

namespace CourseManagement.Application.Course.Command;

public class CreateCourseCommand : CourseInputModel, IRequest<bool>
{
    public string Id { get; set; } = null!;
}

public class CreateCourseCommandHandler :
    IRequestHandler<CreateCourseCommand, bool>
{
    private readonly ICourseService _courseService;

    public CreateCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<bool> Handle(
        CreateCourseCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _courseService.AddCourseAsync(request);
    }
}