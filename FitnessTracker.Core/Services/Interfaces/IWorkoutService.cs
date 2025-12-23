using FitnessTracker.Core.Dtos.WorkoutDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IWorkoutService
{
    Task<IEnumerable<WorkoutDto>> GetAllAsync();
    Task<WorkoutDto> GetByIdAsync(int workoutId);
    Task<WorkoutDto> CreateAsync(CreateWorkoutDto createWorkoutDto);
    Task<WorkoutDto> UpdateAsync(UpdateWorkoutDto updateWorkoutDto);
    Task DeleteAsync(int workoutId);
}
