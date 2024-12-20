using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.Student;

using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Services.Data;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentOutputModel>> GetAllStudentsAsync()
        => await _context.Students
        .AsNoTracking()
        .Where(s => !s.IsDeleted)
        .Select(s => new StudentOutputModel
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            CompletedCourses = s.CompletedCourses
        })
        .ToArrayAsync();

    public async Task<bool> AddStudentAsync(StudentInputModel model)
    {
        Student student = new Student()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };

        await _context.Students.AddAsync(student);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> UpdateStudentAsync(StudentUpdateInputModel model)
    {
        Student? student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == model.Id);

        if (student == null)
        {
            return false;
        }

        student.FirstName = model.FirstName;
        student.LastName = model.LastName;
        student.Email = model.Email;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> RemoveStudentAsync(Guid id)
    {
        var student = await _context.Students
                .FindAsync(id);

        if (student == null)
        {
            return false;
        }

        student.IsDeleted = true;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}