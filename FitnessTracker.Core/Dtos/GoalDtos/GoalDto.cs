namespace FitnessTracker.Core.Dtos.GoalDtos;

public class GoalDto
{
    public int Id { get; set; }
    public string? GoalType { get; set; } = null!;
    public int? TargetValue { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool IsAchieved { get; set; }
    public int? UserId { get; set; }
}
