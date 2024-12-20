using System.Reflection;

using CourseManagement.Application.Course.Command;
using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.Infrastructure;
using CourseManagement.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDatabase(builder.Configuration);

builder.Services.RegisterUserDefinedServices(typeof(IStudentService).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(CreateCourseCommand).Assembly);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();