using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
{
    public WorkoutRepository(FitnessTrackerContext context) : base(context)
    {
    }

    public async Task<bool> ExistsAtStartTimeAsync(int userId, DateTime date, int? excludeWorkoutId = null)
    {
        var query = _context.Workouts.AsQueryable()
            .Where(workout => workout.UserId == userId && workout.Date == date);

        if (excludeWorkoutId.HasValue)
            query = query.Where(workout => workout.Id != excludeWorkoutId.Value);

        return await query.AnyAsync(workout =>
            workout.Date== date.Date &&
            workout.Date.Hour == date.Hour &&
            workout.Date.Minute == date.Minute
        );
    }

    public async Task<IEnumerable<Workout>> GetByUserIdAsync(int userId)
    {
        return await _context.Workouts
            .Where(workout => workout.UserId == userId)
            .OrderByDescending(workout => workout.Date)
            .ToListAsync();
    }
}
