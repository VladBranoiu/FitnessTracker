using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<bool> ExerciseNameAlreadyExistsAsync(string name, int? excludeExerciseId = null);
    Task<bool> ExerciseIsUsedInAnyWorkoutAsync(int exerciseId);
}
