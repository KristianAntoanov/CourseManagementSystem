namespace CourseManagement.Common;

public static class ValidationConstants
{
    public static class Course
    {
        public const int TitleMinLength = 3;
        public const int TitleMaxLength = 100;
        public const string TitleRequiredMessage = "Course title is required.";
        public const string TitleErrorMessage = "Course title must be between {2} and {1} characters long.";

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 500;
        public const string DescriptionRequiredMessage = "Course description is required.";
        public const string DescriptionErrorMessage = "Course description must be between {2} and {1} characters long.";
    }

    public static class Student
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;
        public const string FirstNameRequiredMessage = "First name is required.";
        public const string LastNameRequiredMessage = "Last name is required.";
        public const string NameErrorMessage = "Name must be between {2} and {1} characters long.";

        public const int EmailMaxLength = 100;
        public const string EmailRequiredMessage = "Email is required.";
        public const string EmailInvalidMessage = "Invalid email format.";
    }

    public static class Common
    {
        public const string IdRequiredMessage = "ID is required.";
        public const string InternalServerErrorMessage = "An unexpected error occurred.";
    }
}