using FitnessTracker.Domain.Enums;

namespace FitnessTracker.Core.Dtos.ExerciseDtos;

public class CreateExerciseDto
{
    public string Name { get; set; } = null!;
    public MuscleGroup MuscleGroup { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}
