using CourseManagement.Services.Data.Contracts;

using MediatR;

namespace CourseManagement.Application.Course.Command;

public class RemoveCourseCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand, bool>
{
    private readonly ICourseService _courseService;

    public RemoveCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<bool> Handle(
        RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new InvalidOperationException();
        }

        return await _courseService.RemoveCourseAsync(request.Id);
    }
}