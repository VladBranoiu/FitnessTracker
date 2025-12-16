namespace FitnessTracker.Core.Dtos.ExerciseDtos;

public class CreateExerciseDto
{
    public string Name { get; set; } = null!;
    public string? MuscleGroup { get; set; }
    public string? DifficultyLevel { get; set; }
}
