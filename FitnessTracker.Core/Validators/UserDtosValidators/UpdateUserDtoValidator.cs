using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Infrastructure.Constants;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.UserDtosValidators;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(NameRequired)
            .MaximumLength(50).WithMessage(NameMaxLength);

        RuleFor(x => x.Email)
            .MaximumLength(50)
            .When(x => x.Email is not null)
            .WithMessage(InvalidEmailLength)
            .EmailAddress()
            .When(x => x.Email is not null)
            .WithMessage(InvalidEmail);
        
        RuleFor(x => x.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage(InvalidBirthday)
            .Must(birthDate => birthDate <= DateOnly.FromDateTime(DateTime.Now.AddYears(-13)))
            .WithMessage(MinUserAge);

        RuleFor(x => x.Gender)
            .NotNull().WithMessage(GenderRequired)
            .IsInEnum();

        RuleFor(x => x.Height)
            .NotNull().WithMessage(HeightRequired)
            .InclusiveBetween(50, 250).WithMessage(HeightRange);

        RuleFor(x => x.Weight)
            .NotNull().WithMessage(WeightRequired)
            .InclusiveBetween(20, 300).WithMessage(WeightRange);
    }
}
