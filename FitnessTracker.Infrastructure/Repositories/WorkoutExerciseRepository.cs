using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class WorkoutExerciseRepository : Repository<WorkoutExercise>, IWorkoutExerciseRepository
{
    public WorkoutExerciseRepository(FitnessTrackerContext context) : base(context)
    {
    }

    public async Task<bool> ExistsInWorkoutAsync(int workoutId, int exerciseId, int? excludeWorkoutExerciseId = null)
    {
        return await _context.WorkoutExercises.AnyAsync(workoutExercise =>
            workoutExercise.WorkoutId == workoutId &&
            workoutExercise.ExerciseId == exerciseId &&
            (!excludeWorkoutExerciseId.HasValue || workoutExercise.Id != excludeWorkoutExerciseId.Value));
    }

    public async Task<WorkoutExercise?> GetByIdWithExerciseAndWorkoutAsync(int id)
    {
        return await _context.WorkoutExercises
           .Include(workoutExercise => workoutExercise.Exercise)
           .Include(workoutExercise => workoutExercise.Workout)
           .FirstOrDefaultAsync(workoutExercise => workoutExercise.Id == id);
    }

    public async Task<List<WorkoutExercise>> GetByWorkoutIdAsync(int workoutId, bool includeExercise = false)
    {
        IQueryable<WorkoutExercise> query = _context.WorkoutExercises;

        if (includeExercise)
        {
            query = query.Include(workoutExercise => workoutExercise.Exercise);
        }

        return await query
            .Where(workoutExercise => workoutExercise.WorkoutId == workoutId)
            .ToListAsync();
    }

    public async Task RemoveByWorkoutIdAsync(int workoutId)
    {
        await _context.WorkoutExercises
            .Where(workoutExercise => workoutExercise.WorkoutId == workoutId)
            .ExecuteDeleteAsync();
    }
}
