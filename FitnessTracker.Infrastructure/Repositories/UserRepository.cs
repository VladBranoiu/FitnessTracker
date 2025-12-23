using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(FitnessTrackerContext context) : base(context)
    {
    }

    public Task<bool> ExistsByEmailAsync(string email, int? ignoreUserId = null)
    {
        var userQuery = _context.Users.AsQueryable()
            .Where(user => user.Email == email);

        if(ignoreUserId.HasValue)
            userQuery = userQuery.Where(user => user.Id != ignoreUserId.Value);

        return userQuery.AnyAsync();
    }
}
