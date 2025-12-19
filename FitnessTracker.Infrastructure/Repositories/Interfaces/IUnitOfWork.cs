namespace FitnessTracker.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IWorkoutRepository WorkoutRepository { get; }

    Task SaveChangesAsync();
}
