using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class WorkoutExerciseMapper
{
    public static WorkoutExerciseDto ToDto(WorkoutExercise workoutExercise)
    {
        return new WorkoutExerciseDto
        {
            WorkoutId = workoutExercise.WorkoutId,
            ExerciseId = workoutExercise.ExerciseId,
            Sets = workoutExercise.Sets,
            Reps = workoutExercise.Reps,
            WeightUsed = workoutExercise.WeightUsed
        };
    }

    public static WorkoutExercise ToEntity(CreateWorkoutExerciseDto createWorkoutExerciseDto)
    {
        return new WorkoutExercise
        {
            ExerciseId = createWorkoutExerciseDto.ExerciseId,
            Sets = createWorkoutExerciseDto.Sets,
            Reps = createWorkoutExerciseDto.Reps,
            WeightUsed = createWorkoutExerciseDto.WeightUsed
        };
    }

}
