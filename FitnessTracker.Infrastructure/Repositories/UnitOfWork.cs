using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FitnessTrackerContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public UnitOfWork(FitnessTrackerContext context, IUserRepository userRepository, IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
    }

    public IUserRepository UserRepository => _userRepository;

    public IWorkoutRepository WorkoutRepository => _workoutRepository;

    public IExerciseRepository ExerciseRepository => _exerciseRepository;

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
    
}
