using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);

}
