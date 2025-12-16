using FitnessTracker.Core.Dtos.WorkoutDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class WorkoutMapper
{
    public static WorkoutDto ToDto(Workout workout)
    {
        return new WorkoutDto
        {
            Id = workout.Id,
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
            DurationInMinutes = createDto.DurationInMinutes,
            Notes = createDto.Notes,
            UserId = createDto.UserId
        };
    }
    public static void UpdateEntity(Workout workout, UpdateWorkoutDto updateDto)
    {
        workout.Date = updateDto.Date;
        workout.DurationInMinutes = updateDto.DurationInMinutes;
        workout.Notes = updateDto.Notes;
    }
}
