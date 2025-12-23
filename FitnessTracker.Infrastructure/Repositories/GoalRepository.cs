using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class GoalRepository : Repository<Goal>, IGoalRepository
{
    public GoalRepository(FitnessTrackerContext context) : base(context)
    {
        
    }
    public async Task<List<Goal>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(g => g.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Goal>> GetActiveGoalsAsync(int userId, DateOnly today)
    {
        return await _dbSet
            .Where(g =>
                g.UserId == userId &&
                g.StartDate <= today &&
                g.EndDate >= today &&
                !g.IsAchieved)
            .ToListAsync();
    }
}
