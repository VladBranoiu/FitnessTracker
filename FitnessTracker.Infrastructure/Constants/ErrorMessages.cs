namespace FitnessTracker.Infrastructure.Constants;

public static class ErrorMessages
{
    public const string EmailAlreadyExists = "A user with this email already exists.";
    public const string UserNotFoundById = "User with ID {0} was not found.";
    public const string UserNotFoundByEmail = "User with email {0} was not found.";
   
    public const string WorkoutNotFoundById = "Workout with id {0} was not found.";

    public const string ExerciseNotFoundById = "Exercise with id {0} was not found.";
    public const string ExerciseNameAlreadyExists = 
        "An exercise with the same name already exists.";
    public const string ExerciseDeleteForbiddenUsedInWorkouts =
        "Exercise cannot be deleted because it is used in one or more workouts.";
}
