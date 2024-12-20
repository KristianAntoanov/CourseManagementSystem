using Microsoft.AspNetCore.Mvc;

using CourseManagement.Application.Course.Command;
using CourseManagement.Application.Course.Query;
using CourseManagement.WebApi.IOModels.Course;

using MediatR;

namespace CourseManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : BaseController
{
    public CourseController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(CourseOutputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CourseOutputModel>>> GetAvailableCourses(
        [FromQuery] GetAvailableCoursesQuery query)
        => await Send(query);

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(CourseInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Add(
        [FromBody] CreateCourseCommand command)
        => await Send(command);

    [HttpPut("[action]")]
    [ProducesResponseType(typeof(CourseUpdateInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Update(
        [FromBody] UpdateCourseCommand command)
        => await Send(command);

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Remove(
        [FromBody] RemoveCourseCommand command)
        => await Send(command);
}