namespace FitnessTracker.Core.Dtos.FoodLogDtos;

public class UpdateFoodLogDto
{
    public DateOnly LogDate { get; set; }
    public int Servings { get; set; }
    public int Quantity { get; set; }
    public int FoodId { get; set; }
}
