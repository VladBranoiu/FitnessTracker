using FitnessTracker.Core.Dtos.WorkoutDtos;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.WorkoutDtosValidators;

public class CreateWorkoutDtoValidator : AbstractValidator<CreateWorkoutDto>
{
    public CreateWorkoutDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(WorkoutNameRequired)
            .MaximumLength(100).WithMessage(WorkoutNameMaxLength);

        RuleFor(dto=> dto.Date)
            .NotNull().WithMessage(WorkoutDateNotNull)
            .Must(date=> date <= DateTime.UtcNow)
            .WithMessage(WorkoutDateValidation);

        RuleFor(dto => dto.DurationInMinutes)
            .NotNull()
            .InclusiveBetween(5, 300)
            .WithMessage(WorkoutDurationRange);

        RuleFor(dto=> dto.Notes)
            .MaximumLength(500);
    }
}
