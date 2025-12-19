using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Infrastructure.Constants;
using FluentValidation;
using static FitnessTracker.Infrastructure.Constants.ValidationMessages;

namespace FitnessTracker.Core.Validators.UserDtosValidators;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(NameRequired)
            .MaximumLength(50).WithMessage(NameMaxLength);

        RuleFor(dto => dto.Email)
            .MaximumLength(50)
            .When(dto => dto.Email is not null)
            .WithMessage(InvalidEmailLength)
            .EmailAddress()
            .When(dto => dto.Email is not null)
            .WithMessage(InvalidEmail);
        
        RuleFor(dto => dto.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage(InvalidBirthday)
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
