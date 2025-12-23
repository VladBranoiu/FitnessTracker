using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IWorkoutExerciseService
{
    Task<IEnumerable<WorkoutExerciseDto>> GetAllByWorkoutIdAsync(int workoutId);

    Task<WorkoutExerciseDto> GetByWorkoutAndExerciseIdsAsync(int exerciseId, int workoutId);

    Task<WorkoutExerciseDto> CreateAsync(CreateWorkoutExerciseDto createWorkoutExerciseDto);

    Task<WorkoutExerciseDto> UpdateAsync(UpdateWorkoutExerciseDto dto);

    Task DeleteAsync(int workoutId, int exerciseId);
}
