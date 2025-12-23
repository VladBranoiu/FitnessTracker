using FitnessTracker.Core.Dtos.FoodItemDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IFoodItemService
{
    Task<List<FoodItemDto>> GetAllAsync();
    Task<FoodItemDto?> GetByIdAsync(int id);
    Task<FoodItemDto> CreateAsync(CreateFoodItemDto dto);
    Task<bool> UpdateAsync(int id, UpdateFoodItemDto dto);
    Task<bool> DeleteAsync(int id);
}
