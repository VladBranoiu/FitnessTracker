using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IGoalRepository : IRepository<Goal>
{
    Task<List<Goal>> GetByUserIdAsync(int userId);
    Task<List<Goal>> GetActiveGoalsAsync(int userId, DateOnly today);
}
