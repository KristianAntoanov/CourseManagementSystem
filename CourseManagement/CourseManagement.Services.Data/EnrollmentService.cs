using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Services.Data.Contracts;
using CourseManagement.WebApi.IOModels.StudentCourse;

using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Services.Data;

public class EnrollmentService : IEnrollmentService
{
    private readonly ApplicationDbContext _context;

    public EnrollmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentCourseOutputModel>> GetStudentEnrollmentsAsync(Guid studentId)
        => await _context.StudentCourses
            .AsNoTracking()
            .Where(sc => sc.StudentId == studentId && sc.IsActive)
            .Select(sc => new StudentCourseOutputModel
            {
                CourseId = sc.CourseId,
                CourseTitle = sc.Course.Title,
                EnrollmentDate = sc.EnrollmentDate,
                Progress = sc.Progress,
                IsCompleted = sc.IsCompleted,
                CompletedOn = sc.CompletedOn
            })
            .ToListAsync();

    public async Task<IEnumerable<StudentCourseOutputModel>> GetCompletedCoursesAsync(Guid studentId)
        => await _context.StudentCourses
            .AsNoTracking()
            .Where(sc => sc.StudentId == studentId &&
                        sc.IsCompleted && !sc.IsActive)
            .Select(sc => new StudentCourseOutputModel
            {
                CourseId = sc.CourseId,
                CourseTitle = sc.Course.Title,
                EnrollmentDate = sc.EnrollmentDate,
                Progress = sc.Progress,
                IsCompleted = sc.IsCompleted,
                CompletedOn = sc.CompletedOn
            })
            .ToListAsync();


    public async Task<CourseWithEnrolledStudentsOutputModel> GetCourseWithEnrolledStudentsAsync(Guid courseId)
    {
        var course = await _context.Courses
            .AsNoTracking()
            .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
            .FirstOrDefaultAsync(c => c.Id == courseId);

        if (course == null)
        {
            throw new InvalidOperationException();
        }

        return new CourseWithEnrolledStudentsOutputModel
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            CreatedOn = course.CreatedOn,
            EnrolledStudents = course.StudentCourses
                    .Where(sc => sc.IsActive)
                    .Select(sc => new EnrolledStudentModel
                    {
                        StudentId = sc.StudentId,
                        FirstName = sc.Student.FirstName,
                        LastName = sc.Student.LastName,
                        Email = sc.Student.Email,
                        EnrollmentDate = sc.EnrollmentDate,
                        Progress = sc.Progress
                    })
                    .OrderBy(s => s.EnrollmentDate)
                    .ToList()
        };
    }

    public async Task<bool> EnrollStudentInCourseAsync(Guid studentId, Guid courseId)
    {
        var course = await _context.Courses
            .Include(c => c.StudentCourses)
            .FirstOrDefaultAsync(c => c.Id == courseId);

        if (course == null || !course.IsAvailable)
        {
            return false;
        }

        var student = await _context.Students.FindAsync(studentId);
        if (student == null || course.StudentCourses.Any(sc => sc.StudentId == studentId) ||
            student.IsDeleted || course.IsDeleted)
        {
            return false;
        }

        var studentCourse = new StudentCourse
        {
            StudentId = studentId,
            CourseId = courseId,
            EnrollmentDate = DateTime.Now,
            IsCompleted = false,
            Progress = 0,
            IsActive = true
        };

        course.CurrentStudentsCount++;
        if (course.CurrentStudentsCount > course.MaxStudents)
        {
            course.IsAvailable = false;
            return false;
        }

        await _context.StudentCourses.AddAsync(studentCourse);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateStudentProgressAsync(Guid studentId, Guid courseId, decimal progress)
    {
        var enrollment = await _context.StudentCourses
            .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        if (enrollment == null)
        {
            return false;
        }

        enrollment.Progress = progress;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> CompleteCourseAsync(Guid studentId, Guid courseId)
    {
        var enrollment = await _context.StudentCourses
            .Include(sc => sc.Student)
            .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        if (enrollment == null || enrollment.IsCompleted)
        {
            return false;
        }

        enrollment.IsCompleted = true;
        enrollment.CompletedOn = DateTime.Now;
        enrollment.Progress = 100;
        enrollment.Student.CompletedCourses++;
        enrollment.IsActive = false;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}