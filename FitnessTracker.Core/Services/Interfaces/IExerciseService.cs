using FitnessTracker.Core.Dtos.ExerciseDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IExerciseService
{
    Task<List<ExerciseDto>> GetAllAsync();
    Task<ExerciseDto?> GetByIdAsync(int id);
    Task<ExerciseDto> CreateAsync(CreateExerciseDto createExerciseDto);
    Task<ExerciseDto> UpdateAsync(int id, UpdateExerciseDto updateExerciseDto);
    Task DeleteAsync(int id);
}
