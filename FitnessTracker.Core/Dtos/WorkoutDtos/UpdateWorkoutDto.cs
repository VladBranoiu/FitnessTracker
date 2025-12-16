namespace FitnessTracker.Core.Dtos.WorkoutDtos;

public class UpdateWorkoutDto
{
    public DateOnly? Date { get; set; }
    public int? DurationInMinutes { get; set; }
    public string? Notes { get; set; }
} 
