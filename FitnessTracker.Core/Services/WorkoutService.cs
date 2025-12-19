using FitnessTracker.Core.Dtos.WorkoutDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkoutService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorkoutDto>> GetAllAsync()
    {
        var workouts = await _unitOfWork.WorkoutRepository.GetAllAsync();
        return workouts.Select(WorkoutMapper.ToDto);
    }

    public async Task<WorkoutDto> GetByIdAsync(int id)
    {
        var workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(id);
        if (workout is null)
        {
            throw new NotFoundException(ErrorMessages.WorkoutNotFoundById);
        }

        return WorkoutMapper.ToDto(workout);
    }

    public async Task<WorkoutDto> CreateAsync(CreateWorkoutDto createWorkoutDto)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(createWorkoutDto.UserId);
        if(user is null)
        {
            throw new NotFoundException(ErrorMessages.UserNotFoundById);
        }

        if(createWorkoutDto.Date < user.RegistrationDate)
        {
            throw new BadRequestException(WorkoutBeforeRegistrationValidation);
        }

        var existsAtSameTime = await _unitOfWork.WorkoutRepository
           .ExistsAtStartTimeAsync(
               createWorkoutDto.UserId,
               createWorkoutDto.Date);

        if (existsAtSameTime)
        {
            throw new BadRequestException(WorkoutOverlapValidation);
        }

        var workout = WorkoutMapper.ToEntity(createWorkoutDto);
        await _unitOfWork.WorkoutRepository.AddAsync(workout);
        await _unitOfWork.WorkoutRepository.SaveChangesAsync();

        return WorkoutMapper.ToDto(workout);
    }

    public async Task<WorkoutDto> UpdateAsync(UpdateWorkoutDto updateWorkoutDto)
    {
        var workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(updateWorkoutDto.WorkoutId);
        if (workout is null)
        {
            throw new NotFoundException(ErrorMessages.WorkoutNotFoundById);
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(workout.UserId);
        if (user is null)
        {
            throw new NotFoundException(ErrorMessages.UserNotFoundById);
        }

        if (updateWorkoutDto.Date < user.RegistrationDate)
        {
            throw new BadRequestException(WorkoutBeforeRegistrationValidation);
        }

        var existsAtSameTime = await _unitOfWork.WorkoutRepository
            .ExistsAtStartTimeAsync(
                workout.UserId,
                updateWorkoutDto.Date,
                excludeWorkoutId: workout.Id);

        if (existsAtSameTime)
        {
            throw new BadRequestException(WorkoutOverlapValidation);
        }

        WorkoutMapper.UpdateEntity(workout, updateWorkoutDto);

        await _unitOfWork.SaveChangesAsync();

        return WorkoutMapper.ToDto(workout);
    }

    public async Task DeleteAsync(int id)
    {
        var workout = await _unitOfWork.WorkoutRepository.GetByIdAsync(id);
        if (workout is null)
        {
            throw new NotFoundException(ErrorMessages.WorkoutNotFoundById);
        }

        _unitOfWork.WorkoutRepository.Remove(workout);
        await _unitOfWork.WorkoutRepository.SaveChangesAsync();
    }

}
