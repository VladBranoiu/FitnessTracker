using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IWorkoutRepository : IRepository<Workout>
{
    Task<IEnumerable<Workout>> GetByUserIdAsync(int userId);
    
    Task<bool> ExistsAtStartTimeAsync(int userId, DateTime date, int? excludeWorkoutId = null);
}
