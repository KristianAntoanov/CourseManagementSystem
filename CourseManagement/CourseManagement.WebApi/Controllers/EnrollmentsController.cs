using Microsoft.AspNetCore.Mvc;

using CourseManagement.Application.StudentCourse.Command;
using CourseManagement.Application.StudentCourse.Query;
using CourseManagement.WebApi.IOModels.StudentCourse;

using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CourseManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnrollmentsController : BaseController
{
    public EnrollmentsController(IMediator mediator)
       : base(mediator)
    {
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(IEnumerable<StudentCourseOutputModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<StudentCourseOutputModel>>> GetStudentEnrollments(
        [FromQuery] GetStudentEnrollmentsQuery query)
        => await Send(query);

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(IEnumerable<StudentCourseOutputModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<StudentCourseOutputModel>>> GetCompletedCourses(
    [FromQuery] GetCompletedCoursesQuery query)
    => await Send(query);

    [HttpGet("[action]")]
    public async Task<ActionResult<CourseWithEnrolledStudentsOutputModel>>GetCourseWithEnrolledStudents(
        [FromQuery] GetCourseWithEnrolledStudentsQuery query)
        => await Send(query);
    

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> EnrollStudent(
        [FromBody] EnrollStudentCommand command)
        => await Send(command);

    [HttpPut("[action]")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> UpdateProgress(
        [FromBody] UpdateStudentProgressCommand command)
        => await Send(command);

    [HttpPut("[action]")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> CompleteCourse(
        [FromBody] CompleteCourseCommand command)
        => await Send(command);
}