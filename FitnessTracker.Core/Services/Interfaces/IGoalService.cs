using FitnessTracker.Core.Dtos.GoalDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IGoalService
{
    Task<List<GoalDto>> GetAllAsync();
    Task<GoalDto?> GetByIdAsync(int id);
    Task<List<GoalDto>> GetByUserIdAsync(int userId);
    Task<GoalDto> CreateAsync(CreateGoalDto dto);
    Task<bool> UpdateAsync(int id, UpdateGoalDto dto);
    Task<bool> DeleteAsync(int id);
}
