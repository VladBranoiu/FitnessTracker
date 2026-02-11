using FitnessTracker.Core.Dtos.FoodItemDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.FoodItemDtosValidators;

public class CreateFoodItemDtoValidator : AbstractValidator<CreateFoodItemDto> 
{
    public CreateFoodItemDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Calories)
            .InclusiveBetween(0, 900);

        RuleFor(x => x.Protein)
            .InclusiveBetween(0, 100);

        RuleFor(x => x.Carbs)
            .InclusiveBetween(0, 100);

        RuleFor(x => x.Fat)
            .InclusiveBetween(0, 100);
    }
}
