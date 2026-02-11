namespace FitnessTracker.Core.Dtos.FoodLogDtos;

public class FoodLogDto
{
    public int Id { get; set; }
    public DateOnly LogDate { get; set; }
    public int Servings { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int? FoodId { get; set; }
}
