using Microsoft.AspNetCore.Mvc;

using CourseManagement.Application.Student.Command;
using CourseManagement.Application.Student.Query;
using CourseManagement.WebApi.IOModels.Student;

using MediatR;

namespace CourseManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : BaseController
{
    public StudentsController(IMediator mediator)
         : base(mediator)
    {
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(StudentOutputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<StudentOutputModel>>> GetStudents(
        [FromQuery] GetStudentsQuery query)
        => await Send(query);

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(StudentInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Add(
        [FromBody] CreateStudentCommand command)
        => await Send(command);

    [HttpPut("[action]")]
    [ProducesResponseType(typeof(StudentUpdateInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Update(
        [FromBody] UpdateStudentCommand command)
        => await Send(command);

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Remove(
        [FromBody] RemoveStudentCommand command)
        => await Send(command);
}