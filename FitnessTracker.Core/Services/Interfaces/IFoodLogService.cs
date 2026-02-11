using FitnessTracker.Core.Dtos.FoodLogDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IFoodLogService
{
    Task<List<FoodLogDto>> GetAllAsync();
    Task<FoodLogDto?> GetByIdAsync(int id);
    Task<List<FoodLogDto>> GetByUserIdAsync(int userId);
    Task<FoodLogDto> CreateAsync(CreateFoodLogDto createFoodLogDto);
    Task<bool> UpdateAsync(int id, UpdateFoodLogDto updateFoodLogDto);
    Task<bool> DeleteAsync(int id);
}
