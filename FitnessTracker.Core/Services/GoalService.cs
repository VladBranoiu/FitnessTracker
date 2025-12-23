using FitnessTracker.Core.Dtos.GoalDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<List<GoalDto>> GetAllAsync()
    {
        var goals = await _goalRepository.GetAllAsync();
        return goals.Select(GoalMapper.ToDto).ToList();
    }

    public async Task<GoalDto?> GetByIdAsync(int id)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        return goal == null ? null : GoalMapper.ToDto(goal);
    }

    public async Task<List<GoalDto>> GetByUserIdAsync(int userId)
    {
        var goals = await _goalRepository.GetByUserIdAsync(userId);
        return goals.Select(GoalMapper.ToDto).ToList();
    }

    public async Task<GoalDto> CreateAsync(CreateGoalDto dto)
    {
        var goal = GoalMapper.ToEntity(dto);

        await _goalRepository.AddAsync(goal);
        await _goalRepository.SaveChangesAsync();

        return GoalMapper.ToDto(goal);
    }

    public async Task<bool> UpdateAsync(int id, UpdateGoalDto dto)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        if (goal == null)
            return false;

        GoalMapper.UpdateEntity(goal, dto);
        await _goalRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        if (goal == null)
            return false;

        _goalRepository.Remove(goal);
        await _goalRepository.SaveChangesAsync();

        return true;
    }
}
