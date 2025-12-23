namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IWorkoutRepository WorkoutRepository { get; }
    IExerciseRepository ExerciseRepository { get; }
    IWorkoutExerciseRepository WorkoutExerciseRepository { get; }
    IGoalRepository GoalRepository { get; }
    Task SaveChangesAsync();
}
