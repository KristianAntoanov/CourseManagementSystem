using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected async Task<ActionResult<TResponse>> Send<TResponse>(IRequest<TResponse> request)
    {
        var response = await _mediator.Send(request);

        if (response == null)
        {
            return BadRequest();
        }

        return Ok(response);
    }
}