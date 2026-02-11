namespace FitnessTracker.Core.Dtos.GoalDtos;

public class UpdateGoalDto
{
    public string GoalType { get; set; } = null!;
    public int TargetValue { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
