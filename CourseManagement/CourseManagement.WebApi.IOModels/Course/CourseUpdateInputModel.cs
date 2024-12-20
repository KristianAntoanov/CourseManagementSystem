using System.ComponentModel.DataAnnotations;

using static CourseManagement.Common.ValidationConstants.Course;

namespace CourseManagement.WebApi.IOModels.Course;

public class CourseUpdateInputModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = TitleRequiredMessage)]
    [StringLength(TitleMaxLength,
        MinimumLength = TitleMinLength,
        ErrorMessage = TitleErrorMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = DescriptionRequiredMessage)]
    [StringLength(DescriptionMaxLength,
        MinimumLength = DescriptionMinLength,
        ErrorMessage = DescriptionErrorMessage)]
    public string Description { get; set; } = null!;
}