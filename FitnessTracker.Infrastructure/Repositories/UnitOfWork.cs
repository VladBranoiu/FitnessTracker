using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FitnessTrackerContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IWorkoutExerciseRepository _workoutExerciseRepository;
    private readonly IGoalRepository _goalRepository;
    public UnitOfWork(FitnessTrackerContext context, IUserRepository userRepository, 
        IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, 
        IWorkoutExerciseRepository workoutExerciseRepository, IGoalRepository goalRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
        _workoutExerciseRepository = workoutExerciseRepository;
        _goalRepository = goalRepository;
    }

    public IUserRepository UserRepository => _userRepository;

    public IWorkoutRepository WorkoutRepository => _workoutRepository;

    public IExerciseRepository ExerciseRepository => _exerciseRepository;

    public IWorkoutExerciseRepository WorkoutExerciseRepository => _workoutExerciseRepository;

    public IGoalRepository GoalRepository => _goalRepository;

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
    
}
