using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FitnessTrackerContext _context;
    private IUserRepository? _userRepository;
    private IWorkoutRepository? _workoutRepository;
    private IExerciseRepository? _exerciseRepository;
    private IWorkoutExerciseRepository? _workoutExerciseRepository;
    private IGoalRepository? _goalRepository;
    private IFoodItemRepository? _foodItemRepository;

    public UnitOfWork(FitnessTrackerContext context, IUserRepository userRepository, 
        IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, 
        IWorkoutExerciseRepository workoutExerciseRepository, IGoalRepository goalRepository,
        IFoodItemRepository foodItemRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
        _workoutExerciseRepository = workoutExerciseRepository;
        _goalRepository = goalRepository;
        _foodItemRepository = foodItemRepository;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IWorkoutRepository WorkoutRepository => _workoutRepository ??= new WorkoutRepository(_context);
    public IExerciseRepository ExerciseRepository => _exerciseRepository ??= new ExerciseRepository(_context);
    public IWorkoutExerciseRepository WorkoutExerciseRepository => _workoutExerciseRepository ??= new WorkoutExerciseRepository(_context);
    public IGoalRepository GoalRepository => _goalRepository ??= new GoalRepository(_context);
    public IFoodItemRepository FoodItemRepository => _foodItemRepository ??= new FoodItemRepository(_context);

    public Task SaveChangesAsync() =>  _context.SaveChangesAsync();
    
}
