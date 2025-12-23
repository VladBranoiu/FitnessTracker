using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IWorkoutExerciseRepository : IRepository<WorkoutExercise>
{
    Task<List<WorkoutExercise>> GetByWorkoutIdAsync(int workoutId, bool includeExercise = false);
    Task<WorkoutExercise?> GetByIdWithExerciseAndWorkoutAsync(int id);
    Task<bool> ExistsInWorkoutAsync(int workoutId, int exerciseId, int? excludeWorkoutExerciseId = null);
    Task RemoveByWorkoutIdAsync(int workoutId);
}
