using FitnessTracker.Core.Dtos.ExerciseDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class ExerciseService : IExerciseService
{
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ExerciseDto>> GetAllAsync()
    {
        var exercises = await _unitOfWork.ExerciseRepository.GetAllAsync();
        return exercises.Select(ExerciseMapper.ToDto).ToList();
    }

    public async Task<ExerciseDto?> GetByIdAsync(int id)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdAsync(id);
        if (exercise is null)
        {
            throw new NotFoundException(ErrorMessages.WorkoutNotFoundById);
        }

        return ExerciseMapper.ToDto(exercise);
    }

    public async Task<ExerciseDto> CreateAsync(CreateExerciseDto createExerciseDto)
    {
        var nameExists = await _unitOfWork.ExerciseRepository
            .ExerciseNameAlreadyExistsAsync(createExerciseDto.Name);

        if (nameExists)
        {
            throw new BadRequestException(ErrorMessages.ExerciseNameAlreadyExists);
        }

        var exercise = ExerciseMapper.ToEntity(createExerciseDto);

        await _unitOfWork.ExerciseRepository.AddAsync(exercise);
        await _unitOfWork.SaveChangesAsync();

        return ExerciseMapper.ToDto(exercise);
    }

    public async Task<ExerciseDto> UpdateAsync(int id, UpdateExerciseDto updateExerciseDto)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdAsync(id);
        if (exercise is null)
        {
            throw new NotFoundException(ErrorMessages.ExerciseNotFoundById);
        }

        var nameExists = await _unitOfWork.ExerciseRepository
            .ExerciseNameAlreadyExistsAsync(updateExerciseDto.Name, excludeExerciseId: id);

        if (nameExists)
        {
            throw new BadRequestException(ErrorMessages.ExerciseNameAlreadyExists);
        }

        ExerciseMapper.UpdateEntity(exercise, updateExerciseDto);

        await _unitOfWork.SaveChangesAsync();

        return ExerciseMapper.ToDto(exercise);
    }

    public async Task DeleteAsync(int id)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdAsync(id);

        if (exercise is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.ExerciseNotFoundById, id));
        }

        var isUsed = await _unitOfWork.ExerciseRepository.ExerciseIsUsedInAnyWorkoutAsync(id);
        if (isUsed)
        {
            throw new BadRequestException(ErrorMessages.ExerciseDeleteForbiddenUsedInWorkouts);
        }

        _unitOfWork.ExerciseRepository.Remove(exercise);
        await _unitOfWork.SaveChangesAsync();
    }
}
