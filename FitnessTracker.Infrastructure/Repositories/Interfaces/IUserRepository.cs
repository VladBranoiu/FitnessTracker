using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsByEmailAsync(string email, int? ignoreUserId = null);
}
