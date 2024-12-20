using System.ComponentModel.DataAnnotations;

using static CourseManagement.Common.ValidationConstants.Common;

namespace CourseManagement.WebApi.IOModels.StudentCourse;

public class EnrollStudentInputModel
{
    [Required(ErrorMessage = IdRequiredMessage)]
    public Guid StudentId { get; set; }

    [Required(ErrorMessage = IdRequiredMessage)]
    public Guid CourseId { get; set; }
}