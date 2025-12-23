using FitnessTracker.Core.Dtos.FoodLogDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.FoodLogValidators;

public class CreateFoodLogDtoValidator : AbstractValidator<CreateFoodLogDto>
{
    public CreateFoodLogDtoValidator()
    {
        RuleFor(x => x.Servings)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);

        RuleFor(x => x.LogDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("LogDate can't be in the future.");

        RuleFor(x => x.UserId)
            .GreaterThan(0);

        RuleFor(x => x.FoodId)
            .GreaterThan(0);
    }
}
