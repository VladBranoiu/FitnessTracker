using FitnessTracker.Core.Dtos.FoodItemDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class FoodItemMapper
{
    public static FoodItemDto ToDto(FoodItem foodItem)
    { 
        return new FoodItemDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Calories = foodItem.Calories,
            Protein = foodItem.Protein,
            Carbs = foodItem.Carbs,
            Fat = foodItem.Fat
        };
    }

    public static FoodItem ToEntity(CreateFoodItemDto createFoodItemDto)
    {
        return new FoodItem
        {
            Name = createFoodItemDto.Name,
            Calories = createFoodItemDto.Calories,
            Protein = createFoodItemDto.Protein,
            Carbs = createFoodItemDto.Carbs,
            Fat = createFoodItemDto.Fat
        };
    }

    public static void UpdateEntity(FoodItem foodItem, UpdateFoodItemDto updateFoodItemDto)
    {
        foodItem.Name = updateFoodItemDto.Name;
        foodItem.Calories = updateFoodItemDto.Calories;
        foodItem.Protein = updateFoodItemDto.Protein;
        foodItem.Carbs = updateFoodItemDto.Carbs;
        foodItem.Fat = updateFoodItemDto.Fat;
    }
}
