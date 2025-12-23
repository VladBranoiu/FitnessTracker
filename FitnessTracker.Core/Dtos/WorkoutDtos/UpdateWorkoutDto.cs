namespace FitnessTracker.Core.Dtos.WorkoutDtos;

public class UpdateWorkoutDto
{
    public int WorkoutId { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public string? Notes { get; set; }
} 
