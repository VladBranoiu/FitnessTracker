namespace FitnessTracker.Core.Dtos.FoodItemDtos;

public class CreateFoodItemDto
{
    public string Name { get; set; } = null!;
    public decimal? Calories { get; set; }
    public decimal? Protein { get; set; }
    public decimal? Carbs { get; set; }
    public decimal? Fat { get; set; }
}
