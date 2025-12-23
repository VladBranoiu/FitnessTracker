using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(FitnessTrackerContext context) : base(context)
    {
    }
    public async Task<bool> ExerciseNameAlreadyExistsAsync(string name, int? excludeExerciseId = null)
    {
        var query = _context.Exercises.Where(exercise => exercise.Name == name);

        if (excludeExerciseId.HasValue)
            query = query.Where(exercise => exercise.Id != excludeExerciseId.Value);

        return await query.AnyAsync();
    }

    public async Task<bool> ExerciseIsUsedInAnyWorkoutAsync(int exerciseId)
    {
        return await _context.WorkoutExercises.AnyAsync(workoutExercise => workoutExercise.ExerciseId == exerciseId);
    }
}
