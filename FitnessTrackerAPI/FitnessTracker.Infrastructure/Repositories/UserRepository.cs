using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FitnessTrackerContext _context;

    public UserRepository(FitnessTrackerContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user) 
    {
        await _context.Users.AddAsync(user);
    }

    public Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        var query = _context.Users.AsQueryable()
                                  .Where(u => u.Email == email);
        if (excludeId.HasValue)
            query = query.Where(u => u.Id != excludeId.Value);

        return query.AnyAsync();
    }

    public async Task<User> GetByIdAsync(int id) =>  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
}
