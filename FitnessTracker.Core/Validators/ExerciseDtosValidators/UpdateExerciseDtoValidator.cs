using FitnessTracker.Core.Dtos.ExerciseDtos;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.ExerciseDtosValidators;

public class UpdateExerciseDtoValidator : AbstractValidator<CreateExerciseDto>
{
    public UpdateExerciseDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(ExerciseNameRequired)
            .MaximumLength(50).WithMessage(ExerciseNameMaxLength);

        RuleFor(dto => dto.MuscleGroup)
            .IsInEnum().WithMessage(InvalidMuscleGroup);

        RuleFor(dto => dto.DifficultyLevel)
            .IsInEnum().WithMessage(InvalidDifficultyLevel);
    }
}
