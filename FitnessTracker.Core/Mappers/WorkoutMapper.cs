using FitnessTracker.Core.Dtos.WorkoutDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class WorkoutMapper
{
    public static WorkoutDto ToDto(Workout workout)
    {
        return new WorkoutDto
        {
            WorkoutId = workout.Id,
            Name = workout.Name,
            Date = workout.Date,
            DurationInMinutes = workout.DurationInMinutes,
            Notes = workout.Notes,
            UserId = workout.UserId
        };
    }
    public static Workout ToEntity(CreateWorkoutDto createDto)
    {
        return new Workout
        {
            Date = createDto.Date,
            Name = createDto.Name,
            DurationInMinutes = createDto.DurationInMinutes,
            Notes = createDto.Notes,
            UserId = createDto.UserId
        };
    }
    public static void UpdateEntity(Workout workout, UpdateWorkoutDto updateDto)
    {
        workout.Name = updateDto.Name;
        workout.Date = updateDto.Date;
        workout.DurationInMinutes = updateDto.DurationInMinutes;
        workout.Notes = updateDto.Notes;
    }
}
