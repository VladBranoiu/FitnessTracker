namespace FitnessTracker.Core.Dtos.ExerciseDtos;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? MuscleGroup { get; set; }
    public string? DifficultyLevel { get; set; }
}
