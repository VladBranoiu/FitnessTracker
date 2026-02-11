using FitnessTracker.Core.Dtos.FoodLogDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FitnessTracker.Core.Services;

public class FoodLogService : IFoodLogService
{
    private readonly IRepository<FoodLog> _foodLogRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<FoodItem> _foodItemRepository;

    public FoodLogService(
        IRepository<FoodLog> foodLogRepository,
        IRepository<User> userRepository,
        IRepository<FoodItem> foodItemRepository)
    {
        _foodLogRepository = foodLogRepository;
        _userRepository = userRepository;
        _foodItemRepository = foodItemRepository;
    }

    public async Task<List<FoodLogDto>> GetAllAsync()
    {
        var logs = await _foodLogRepository.GetAllAsync();
        return logs.Select(FoodLogMapper.ToDto).ToList();
    }

    public async Task<FoodLogDto?> GetByIdAsync(int id)
    {
        var log = await _foodLogRepository.GetByIdAsync(id);
        return log == null ? null : FoodLogMapper.ToDto(log);
    }

    public async Task<List<FoodLogDto>> GetByUserIdAsync(int userId)
    {
        var logs = await _foodLogRepository.FindAsync(l => l.UserId == userId);
        return logs.Select(FoodLogMapper.ToDto).ToList();
    }

    public async Task<FoodLogDto> CreateAsync(CreateFoodLogDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user == null)
            throw new NotFoundException("User not found.");

        var food = await _foodItemRepository.GetByIdAsync(dto.FoodId);
        if (food == null)
            throw new NotFoundException("Food item not found.");

        var regDate = DateOnly.FromDateTime(user.RegistrationDate);
        if (dto.LogDate < regDate)
            throw new BadRequestException("Users can't log food before their registration date.");

        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        if (dto.LogDate > today)
            throw new BadRequestException("LogDate can't be in the future.");

        var entity = FoodLogMapper.ToEntity(dto);

        await _foodLogRepository.AddAsync(entity);
        await _foodLogRepository.SaveChangesAsync();

        return FoodLogMapper.ToDto(entity);
    }

    public async Task<bool> UpdateAsync(int id, UpdateFoodLogDto dto)
    {
        var entity = await _foodLogRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        var food = await _foodItemRepository.GetByIdAsync(dto.FoodId);
        if (food == null)
            throw new NotFoundException("Food item not found.");

        var user = await _userRepository.GetByIdAsync(entity.UserId);
        if (user == null)
            throw new NotFoundException("User not found.");

        var regDate = DateOnly.FromDateTime(user.RegistrationDate);
        if (dto.LogDate < regDate)
            throw new BadRequestException("Users can't log food before their registration date.");

        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        if (dto.LogDate > today)
            throw new BadRequestException("LogDate can't be in the future.");

        FoodLogMapper.UpdateEntity(entity, dto);
        await _foodLogRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _foodLogRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        _foodLogRepository.Remove(entity);
        await _foodLogRepository.SaveChangesAsync();

        return true;
    }
}
