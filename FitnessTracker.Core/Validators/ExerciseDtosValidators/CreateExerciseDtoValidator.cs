using FitnessTracker.Core.Dtos.ExerciseDtos;
using FluentValidation;
using System.Xml;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.ExerciseDtosValidators;

public class CreateExerciseDtoValidator : AbstractValidator<CreateExerciseDto>
{
    public CreateExerciseDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(ExerciseNameRequired)
            .MaximumLength(50).WithMessage(ExerciseNameMaxLength);

        RuleFor(dto => dto.MuscleGroup)
            .NotNull().WithMessage(InvalidMuscleGroup);

        RuleFor(dto => dto.DifficultyLevel)
            .IsInEnum().WithMessage(InvalidDifficultyLevel);
    }
}
