using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Constants;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Services;

public class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _workoutExerciseRepository;
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public WorkoutExerciseService(IWorkoutExerciseRepository workoutExerciseRepository,
        IWorkoutRepository workoutRepository,
        IExerciseRepository exerciseRepository)

    {
        _workoutExerciseRepository = workoutExerciseRepository;
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<List<WorkoutExerciseDto>> GetByWorkoutIdAsync(int userId, int workoutId)
    {
        Workout? workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null || workout.UserId != userId)
            throw new NotFoundException(WorkoutNotFound);

        List<WorkoutExercise> workoutExercises =
            await _workoutExerciseRepository.GetByWorkoutIdAsync(workoutId, includeExercise: true);

        return workoutExercises
            .Select(workoutExercise => WorkoutExerciseMapper.ToDto(workoutExercise))
            .ToList();
    }

    public async Task<WorkoutExerciseDto> CreateAsync(int userId, int workoutId, CreateWorkoutExerciseDto createWorkoutExerciseDto)
    {
        Workout? workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null || workout.UserId != userId)
            throw new NotFoundException(WorkoutNotFound);

        Exercise? exercise = await _exerciseRepository.GetByIdAsync(createWorkoutExerciseDto.ExerciseId);
        if (exercise == null)
            throw new NotFoundException(ExerciseNotFound);

        bool existsInWorkout = await _workoutExerciseRepository.ExistsInWorkoutAsync(
            workoutId,
            createWorkoutExerciseDto.ExerciseId);

        if (existsInWorkout)
            throw new BadRequestException(WorkoutExerciseAlreadyExists);

        WorkoutExercise workoutExercise = WorkoutExerciseMapper.ToEntity(createWorkoutExerciseDto);
        workoutExercise.WorkoutId = workoutId;

        await _workoutExerciseRepository.AddAsync(workoutExercise);
        await _workoutExerciseRepository.SaveChangesAsync();

        return WorkoutExerciseMapper.ToDto(workoutExercise);
    }

    public async Task<WorkoutExerciseDto> UpdateAsync(int userId, int workoutId, int workoutExerciseId, UpdateWorkoutExerciseDto updateWorkoutExerciseDto)
    {
        Workout? workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null || workout.UserId != userId)
            throw new NotFoundException(WorkoutNotFound);

        WorkoutExercise? workoutExercise = await _workoutExerciseRepository.GetByIdAsync(workoutExerciseId);
        if (workoutExercise == null || workoutExercise.WorkoutId != workoutId)
            throw new NotFoundException(WorkoutExerciseNotFound);


        workoutExercise.Sets = updateWorkoutExerciseDto.Sets;
        workoutExercise.Reps = updateWorkoutExerciseDto.Reps;
        workoutExercise.WeightUsed = updateWorkoutExerciseDto.WeightUsed;

        await _workoutExerciseRepository.SaveChangesAsync();

        return WorkoutExerciseMapper.ToDto(workoutExercise);

    }

    public async Task DeleteAsync(int userId, int workoutId, int workoutExerciseId)
    {
        Workout? workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null || workout.UserId != userId)
            throw new NotFoundException(WorkoutNotFound);

        WorkoutExercise? workoutExercise = await _workoutExerciseRepository.GetByIdAsync(workoutExerciseId);
        if (workoutExercise == null || workoutExercise.WorkoutId != workoutId)
            throw new NotFoundException(WorkoutExerciseNotFound);

        _workoutExerciseRepository.Remove(workoutExercise);
        await _workoutExerciseRepository.SaveChangesAsync();
    }

}
