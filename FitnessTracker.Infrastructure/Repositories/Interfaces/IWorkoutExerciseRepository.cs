using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IWorkoutExerciseRepository : IRepository<WorkoutExercise>
{
    Task<List<WorkoutExercise>> GetByWorkoutIdAsync(int workoutId, bool includeExercise = false);
    Task<WorkoutExercise?> GetByIdWithExerciseAndWorkoutAsync(int workoutId, int exerciseId);
    Task<bool> ExistsInWorkoutAsync(int workoutId, int exerciseId, int? excludeWorkoutId = null, int? excludeExerciseId = null);
    Task RemoveByWorkoutIdAsync(int workoutId);
    Task<IEnumerable<WorkoutExercise>> GetAllByWorkoutIdAsync(int workoutId);
    Task<WorkoutExercise?> GetByWorkoutAndExerciseIdsAsync(int workoutId, int exerciseId);
    Task RemoveRange(int workoutId);
}
