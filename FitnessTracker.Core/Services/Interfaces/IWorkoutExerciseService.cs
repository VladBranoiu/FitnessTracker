using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IWorkoutExerciseService
{
    Task<List<WorkoutExerciseDto>> GetByWorkoutIdAsync(int userId, int workoutId);

    Task<WorkoutExerciseDto> CreateAsync(int userId, int workoutId, CreateWorkoutExerciseDto createWorkoutExerciseDto);

    Task<WorkoutExerciseDto> UpdateAsync(int userId, int workoutId, int workoutExerciseId, UpdateWorkoutExerciseDto dto);

    Task DeleteAsync(int userId, int workoutId, int workoutExerciseId);
}
