namespace FitnessTracker.Infrastructure.Constants;

public static class ValidationMessages
{
    //User
    public const string UserNameRequired = "Name is required";
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

    //Workout
    public const string WorkoutNameRequired = "Workout name is required.";
    public const string WorkoutNameMaxLength = "Workout name must not exceed 100 characters.";
    public const string WorkoutDateValidation = "Workout date cannot be in the future.";
    public const string WorkoutDurationRange = "Duration must be between 5 and 300 minutes.";
    public const string WorkoutBeforeRegistrationValidation = "Workout date cannot be before user registration date.";
    public const string WorkoutOverlapValidation = "Workout time overlaps with an existing workout.";
    public const string DurationPositive = "Duration must be a positive value.";
    public const string DurationMaxLimit = "Duration exceeds the maximum allowed limit.";
    public const string WorkoutDateNotNull = "The date must be not null";

    //Exercise
    public const string ExerciseNameRequired = "Exercise name is required.";
    public const string ExerciseNameMaxLength = "Exercise name must not exceed 50 characters.";

    public const string MuscleGroupRequired = "Muscle group is required.";
    public const string InvalidMuscleGroup = "Invalid muscle group value.";

    public const string DifficultyLevelRequired = "Difficulty level is required.";
    public const string InvalidDifficultyLevel = "Invalid difficulty level value.";

    //WorkoutExercise
    public const string WorkoutExerciseNotFound = "Workout exercise not found.";
    public const string WorkoutExerciseAlreadyExists = "Exercise already exists in this workout.";
    public const string ExerciseNotFound = "Exercise not found.";
    public const string WorkoutNotFound = "Workout not found.";

    public const string SetsInvalid = "Sets must be greater than 0.";
    public const string RepsInvalid = "Reps must be greater than 0.";
    public const string WeightInvalid = "Weight must be greater or equal to 0.";
}
