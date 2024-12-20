using System.ComponentModel.DataAnnotations;

using static CourseManagement.Common.ValidationConstants.Student;

namespace CourseManagement.WebApi.IOModels.Student;

public class StudentUpdateInputModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = FirstNameRequiredMessage)]
    [StringLength(NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessage = NameErrorMessage)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = LastNameRequiredMessage)]
    [StringLength(NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessage = NameErrorMessage)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = EmailRequiredMessage)]
    [EmailAddress(ErrorMessage = EmailInvalidMessage)]
    [StringLength(EmailMaxLength)]
    public string Email { get; set; } = null!;
}