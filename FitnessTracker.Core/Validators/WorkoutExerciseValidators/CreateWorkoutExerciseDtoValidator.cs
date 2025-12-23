using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.WorkoutExerciseValidators;

public class CreateWorkoutExerciseDtoValidator : AbstractValidator<WorkoutExerciseDto>
{
    public CreateWorkoutExerciseDtoValidator()
    {
        RuleFor(dto => dto.ExerciseId)
           .GreaterThan(0);

        RuleFor(dto => dto.Sets)
                .GreaterThan(0)
                .LessThanOrEqualTo(50);

        RuleFor(dto => dto.Reps)
                .GreaterThan(0)
                .LessThanOrEqualTo(200);

        RuleFor(dto => dto.WeightUsed)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(500);
    }
}
