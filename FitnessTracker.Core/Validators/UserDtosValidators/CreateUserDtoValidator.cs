using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Infrastructure.Constants;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.UserDtosValidators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Name)
               .NotEmpty().WithMessage(NameRequired)
               .MaximumLength(50).WithMessage(NameMaxLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(EmailRequired)
                .MaximumLength(50).WithMessage(InvalidEmailLength)
                .EmailAddress().WithMessage(InvalidEmail);

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage(BirthdayRequired)
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage(InvalidBirthday)
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
