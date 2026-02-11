using FitnessTracker.Core.Dtos.GoalDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;
    private readonly IUserRepository _userRepository;

    public GoalService(IGoalRepository goalRepository, IUserRepository userRepository)
    {
        _goalRepository = goalRepository;
        _userRepository = userRepository;

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

    public async Task<GoalDto> CreateAsync(CreateGoalDto createGoalDto)
    {
        var user = await _userRepository.GetByIdAsync(createGoalDto.UserId);
        if (user == null)
            throw new NotFoundException("User not found.");

        var registrationDate = DateOnly.FromDateTime(user.RegistrationDate);
        if (createGoalDto.StartDate < registrationDate)
            throw new BadRequestException("StartDate cannot be before user's RegistrationDate.");

        var goal = GoalMapper.ToEntity(createGoalDto);

        await _goalRepository.AddAsync(goal);
        await _goalRepository.SaveChangesAsync();

        return GoalMapper.ToDto(goal);
    }

    public async Task<bool> UpdateAsync(int id, UpdateGoalDto updateGoalDto)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        if (goal == null)
            return false;

        GoalMapper.UpdateEntity(goal, updateGoalDto);
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
