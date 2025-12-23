namespace FitnessTracker.Core.Dtos.WorkoutExerciseDtos;

public class WorkoutExerciseDto
{
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal WeightUsed { get; set; }
}
