using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Course;

using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Services.Data;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;

    public CourseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CourseOutputModel>> GetAllAvailableCoursesAsync()
        => await _context.Courses
        .AsNoTracking()
        .Where(c => c.IsAvailable && !c.IsDeleted)
        .Select(c => new CourseOutputModel()
        {
            Title = c.Title,
            Description = c.Description,
            CreatedOn = c.CreatedOn
        })
        .ToArrayAsync();

    public async Task<bool> AddCourseAsync(CourseInputModel model)
    {
        Course course = new Course()
        {
            Title = model.Title,
            Description = model.Description,
            CreatedOn = DateTime.Now,
            IsAvailable = true
        };

        await _context.Courses.AddAsync(course);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> UpdateCourseAsync(CourseUpdateInputModel model)
    {
        Course? course = await _context.Courses
                .FirstOrDefaultAsync(s => s.Id == model.Id);

        if (course == null)
        {
            return false;
        }

        course.Title = model.Title;
        course.Description = model.Description;
        course.ModifiedOn = DateTime.Now;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> RemoveCourseAsync(Guid id)
    {
        var course = await _context.Courses
                .FindAsync(id);

        if (course == null)
        {
            return false;
        }

        course.IsDeleted = true;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}