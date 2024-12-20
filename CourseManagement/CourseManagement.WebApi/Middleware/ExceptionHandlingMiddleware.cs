using System.Net;
using System.Net.Mime;
using System.Text.Json;

using static CourseManagement.Common.ValidationConstants.Common;

namespace CourseManagement.WebApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, InternalServerErrorMessage);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        var response = new ErrorResponse();

        switch (exception)
        {
            case ArgumentNullException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                break;
            case ArgumentException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                break;
            case InvalidOperationException ex:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = ex.Message;
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = InternalServerErrorMessage;
                break;
        }

        response.StatusCode = context.Response.StatusCode;

        var result = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(result);
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}