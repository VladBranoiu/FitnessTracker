using FitnessTracker.Core.Dtos.MeasurementLogDtos;
using FluentValidation;

namespace FitnessTracker.Core.Validators.MeasurementLogDtoValidators;

public class UpdateMeasurementLogValidator : AbstractValidator<UpdateMeasurementLogDto>
{
    public UpdateMeasurementLogValidator()
    {
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Date can't be in the future.");

        RuleFor(x => x.Weight)
            .GreaterThan(0);

        //cm
        RuleFor(x => x.BodyFatPercentage)
            .InclusiveBetween(2, 60)
            .When(x => x.BodyFatPercentage.HasValue);

        RuleFor(x => x.WaistCircumference)
            .InclusiveBetween(40, 200)
            .When(x => x.WaistCircumference.HasValue);

        RuleFor(x => x.Chest)
            .InclusiveBetween(50, 200)
            .When(x => x.Chest.HasValue);

        RuleFor(x => x.Arms)
            .InclusiveBetween(15, 80)
            .When(x => x.Arms.HasValue);
    }
}
