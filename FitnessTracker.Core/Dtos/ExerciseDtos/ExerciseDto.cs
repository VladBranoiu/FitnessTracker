using FitnessTracker.Domain.Enums;

namespace FitnessTracker.Core.Dtos.ExerciseDtos;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public MuscleGroup MuscleGroup { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}
