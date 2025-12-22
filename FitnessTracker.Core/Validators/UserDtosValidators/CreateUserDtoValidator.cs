using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Infrastructure.Constants;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.UserDtosValidators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(dto => dto.Name)
               .NotEmpty().WithMessage(UserNameRequired)
               .MaximumLength(50).WithMessage(NameMaxLength);

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(EmailRequired)
                .MaximumLength(50).WithMessage(InvalidEmailLength)
                .EmailAddress().WithMessage(InvalidEmail);

        RuleFor(dto => dto.BirthDate)
            .NotEmpty().WithMessage(BirthdayRequired)
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage(InvalidBirthday)
            .Must(birthDate => birthDate <= DateOnly.FromDateTime(DateTime.Now.AddYears(-13)))
            .WithMessage(MinUserAge);

        RuleFor(dto => dto.Gender)
            .NotNull().WithMessage(GenderRequired)
            .IsInEnum();

        RuleFor(dto => dto.Height)
            .NotNull().WithMessage(HeightRequired)
            .InclusiveBetween(50, 250).WithMessage(HeightRange);

        RuleFor(dto => dto.Weight)
            .NotNull().WithMessage(WeightRequired)
            .InclusiveBetween(20, 300).WithMessage(WeightRange);
    }
}
