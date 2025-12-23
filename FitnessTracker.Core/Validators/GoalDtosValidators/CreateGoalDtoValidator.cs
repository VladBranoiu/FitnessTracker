using FitnessTracker.Core.Dtos.GoalDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.GoalDtosValidators;

public class CreateGoalDtoValidator : AbstractValidator<CreateGoalDto>
{
    public CreateGoalDtoValidator()
    {
        RuleFor(x => x.GoalType)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.TargetValue)
            .GreaterThan(0);

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate);

        RuleFor(x => x.UserId)
            .GreaterThan(0);
    }
}
