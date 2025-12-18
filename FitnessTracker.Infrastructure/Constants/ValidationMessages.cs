namespace FitnessTracker.Infrastructure.Constants;

public static class ValidationMessages
{
    public const string NameRequired = "Name is required";
    public const string EmailRequired = "Email is required";
    public const string BirthdayRequired = "Birthday is required";
    public const string GenderRequired = "Gender is required";
    public const string HeightRequired = "Height is required";
    public const string WeightRequired = "Weight is required";

    public const string InvalidNameLength = "Invalid name length";
    public const string InvalidEmail = "Invalid email address";
    public const string InvalidEmailLength = "Invalid email length";
    public const string InvalidBirthday = "Birthday can't be in the future";
    public const string InvalidHeight = "Invalid height";
    public const string InvalidWeight = "Invalid weight";

    public const string NameMaxLength = "Name must not exceed 50 characters.";
    public const string EmailMaxLength = "Email must be at most 50 characters.";
    public const string MinUserAge = "User must be at least 13 years old.";
    public const string HeightRange = "Height must be between 50 and 250 cm.";
    public const string WeightRange = "Weight must be between 20 and 300 kg.";
}
