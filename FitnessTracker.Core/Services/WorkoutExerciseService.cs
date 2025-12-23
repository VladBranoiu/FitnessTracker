using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Services;

public class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkoutExerciseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorkoutExerciseDto>> GetAllByWorkoutIdAsync(int workoutId)
    {
        Workout workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(workoutId)
            ?? throw new NotFoundException(WorkoutNotFound);

        var workoutExercises = await _unitOfWork.WorkoutExerciseRepository.GetAllByWorkoutIdAsync(workoutId);
        return workoutExercises.Select(WorkoutExerciseMapper.ToDto);
    }

    public async Task<WorkoutExerciseDto> GetByWorkoutAndExerciseIdsAsync(int exerciseId, int workoutId)
    {
        WorkoutExercise? workoutExercise = await _unitOfWork.WorkoutExerciseRepository.GetByWorkoutAndExerciseIdsAsync(workoutId, exerciseId);
        if (workoutExercise == null)
            throw new NotFoundException(WorkoutExerciseNotFound);

        return WorkoutExerciseMapper.ToDto(workoutExercise);
    }

    public async Task<WorkoutExerciseDto> CreateAsync(CreateWorkoutExerciseDto createWorkoutExerciseDto)
    {
        Workout? workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(createWorkoutExerciseDto.WorkoutId);
        if (workout == null)
            throw new NotFoundException(WorkoutNotFound);

        Exercise? exercise = await _unitOfWork.ExerciseRepository.GetByIdAsync(createWorkoutExerciseDto.ExerciseId);
        if (exercise == null)
            throw new NotFoundException(ExerciseNotFound);

        bool existsInWorkout = await _unitOfWork.WorkoutExerciseRepository.ExistsInWorkoutAsync(
            createWorkoutExerciseDto.WorkoutId,
            createWorkoutExerciseDto.ExerciseId);

        if (existsInWorkout)
            throw new BadRequestException(WorkoutExerciseAlreadyExists);

        WorkoutExercise workoutExercise = WorkoutExerciseMapper.ToEntity(createWorkoutExerciseDto);
        workoutExercise.WorkoutId = createWorkoutExerciseDto.WorkoutId;

        await _unitOfWork.WorkoutExerciseRepository.AddAsync(workoutExercise);
        await _unitOfWork.WorkoutExerciseRepository.SaveChangesAsync();

        return WorkoutExerciseMapper.ToDto(workoutExercise);
    }

    public async Task<WorkoutExerciseDto> UpdateAsync(UpdateWorkoutExerciseDto updateWorkoutExerciseDto)
    {
        Workout? workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(updateWorkoutExerciseDto.WorkoutId);
        if (workout == null)
            throw new NotFoundException(WorkoutNotFound);

        WorkoutExercise? workoutExercise = await _unitOfWork.WorkoutExerciseRepository.GetByWorkoutAndExerciseIdsAsync(updateWorkoutExerciseDto.WorkoutId, updateWorkoutExerciseDto.ExerciseId);
        if (workoutExercise == null)
            throw new NotFoundException(WorkoutExerciseNotFound);


        workoutExercise.Sets = updateWorkoutExerciseDto.Sets;
        workoutExercise.Reps = updateWorkoutExerciseDto.Reps;
        workoutExercise.WeightUsed = updateWorkoutExerciseDto.WeightUsed;

        await _unitOfWork.WorkoutExerciseRepository.SaveChangesAsync();

        return WorkoutExerciseMapper.ToDto(workoutExercise);

    }

    public async Task DeleteAsync(int workoutId, int exerciseId)
    {
        WorkoutExercise? workoutExercise = await _unitOfWork.WorkoutExerciseRepository.GetByWorkoutAndExerciseIdsAsync(workoutId, exerciseId);
        if (workoutExercise == null)
            throw new NotFoundException(WorkoutExerciseNotFound);

        _unitOfWork.WorkoutExerciseRepository.Remove(workoutExercise);
        await _unitOfWork.WorkoutExerciseRepository.SaveChangesAsync();
    }

}
