using FitnessTracker.Core.Dtos.GoalDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.GoalDtosValidators;

public class UpdateGoalDtoValidator : AbstractValidator<UpdateGoalDto>
{
    public UpdateGoalDtoValidator()
    {
        RuleFor(x => x.GoalType)
           .NotEmpty()
           .MaximumLength(100);

        RuleFor(x => x.TargetValue)
            .GreaterThan(0);

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate);
    }
}
