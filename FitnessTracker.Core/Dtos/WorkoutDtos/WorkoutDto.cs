namespace FitnessTracker.Core.Dtos.WorkoutDtos;

public class WorkoutDto
{
    public int WorkoutId { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public string? Notes { get; set; }
    public int UserId { get; set; }
}
