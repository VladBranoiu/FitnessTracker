using FitnessTracker.Core.Dtos.ExerciseDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class ExerciseMapper
{
    public static ExerciseDto ToDto(Exercise exercise)
    {
        return new ExerciseDto
        {
            Id = exercise.Id,
            Name = exercise.Name,
            MuscleGroup = exercise.MuscleGroup,
            DifficultyLevel = exercise.DifficultyLevel
        };
    }

    public static Exercise ToEntity(CreateExerciseDto createExerciseDto)
    {
        return new Exercise
        {
            Name = createExerciseDto.Name,
            MuscleGroup = createExerciseDto.MuscleGroup,
            DifficultyLevel = createExerciseDto.DifficultyLevel
        };
    }
    public static void UpdateEntity(Exercise exercise, UpdateExerciseDto updateExerciseDto)
    {
        exercise.Name = updateExerciseDto.Name;
        exercise.MuscleGroup = updateExerciseDto.MuscleGroup;
        exercise.DifficultyLevel = updateExerciseDto.DifficultyLevel;
    }
}
