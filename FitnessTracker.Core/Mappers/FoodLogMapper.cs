using FitnessTracker.Core.Dtos.FoodLogDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class FoodLogMapper
{
    public static FoodLogDto ToDto(FoodLog foodLog)
    {
        return new FoodLogDto
        {
            Id = foodLog.Id,
            LogDate = foodLog.LogDate ?? default,
            Servings = foodLog.Servings,
            Quantity = foodLog.Quantity,
            UserId = foodLog.UserId,
            FoodId = foodLog.FoodId
        };
    }
    public static FoodLog ToEntity(CreateFoodLogDto createFoodLogDto)
    {
        return new FoodLog
        {
            LogDate = createFoodLogDto.LogDate,
            Servings = createFoodLogDto.Servings,
            Quantity = createFoodLogDto.Quantity,
            UserId = createFoodLogDto.UserId,
            FoodId = createFoodLogDto.FoodId
        };
    }
}
