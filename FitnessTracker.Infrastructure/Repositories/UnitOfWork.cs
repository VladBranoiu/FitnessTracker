using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FitnessTrackerContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public UnitOfWork(FitnessTrackerContext context, IUserRepository userRepository, IWorkoutRepository workoutRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _workoutRepository = workoutRepository;
    }

    public IUserRepository UserRepository => _userRepository;

    public IWorkoutRepository WorkoutRepository => _workoutRepository;

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
    
}
