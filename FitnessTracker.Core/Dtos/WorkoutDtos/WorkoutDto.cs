namespace FitnessTracker.Core.Dtos.WorkoutDtos;

public class WorkoutDto
{
    public int Id { get; set; }
    public DateOnly? Date { get; set; }
    public int? DurationInMinutes { get; set; }
    public string? Notes { get; set; }
    public int? UserId { get; set; }
}
