using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class WorkoutExerciseRepository : Repository<WorkoutExercise>, IWorkoutExerciseRepository
{
    public WorkoutExerciseRepository(FitnessTrackerContext context) : base(context)
    {
    }

    public async Task<bool> ExistsInWorkoutAsync(
    int workoutId,
    int exerciseId,
    int? excludeWorkoutId = null,
    int? excludeExerciseId = null)
    {
        return await _context.WorkoutExercises.AnyAsync(workoutExercise =>
            workoutExercise.WorkoutId == workoutId &&
            workoutExercise.ExerciseId == exerciseId &&
            (!excludeWorkoutId.HasValue || workoutExercise.WorkoutId != excludeWorkoutId.Value || workoutExercise.ExerciseId != excludeExerciseId!.Value));
    }


    public async Task<WorkoutExercise?> GetByIdWithExerciseAndWorkoutAsync(int workoutId, int exerciseId)
    {
        return await _context.WorkoutExercises
            .Include(workoutExercise => workoutExercise.Exercise)
            .Include(workoutExercise => workoutExercise.Workout)
            .FirstOrDefaultAsync(workoutExercise => workoutExercise.WorkoutId == workoutId && workoutExercise.ExerciseId == exerciseId);
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

    public async Task<IEnumerable<WorkoutExercise>> GetAllByWorkoutIdAsync(int workoutId)
    {
       return  await _context.WorkoutExercises.Where(workoutExercise => workoutExercise.WorkoutId == workoutId).ToListAsync();  
    }

    public async Task<WorkoutExercise?> GetByWorkoutAndExerciseIdsAsync(int workoutId, int exerciseId)
    {
        return await _context.WorkoutExercises.FirstOrDefaultAsync(workoutExercise => workoutExercise.WorkoutId == workoutId &&
            workoutExercise.ExerciseId == exerciseId);
    }

    public async Task RemoveRange(int workoutId)
    {
        await _context.WorkoutExercises.Where(workoutExercise => workoutExercise.WorkoutId == workoutId)
            .ExecuteDeleteAsync();
    }
}
