using FitnessTracker.Core.Dtos.MeasurementLogDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class MeasurementLogMapper
{
    public static MeasurementLogDto ToDto(MeasurementLog measurementLog)
    {
        return new MeasurementLogDto
        {
            Id = measurementLog.Id,
            Date = measurementLog.Date ?? default,
            Weight = measurementLog.Weight,
            BodyFatPercentage = measurementLog.BodyFatPercentage,
            WaistCircumference = measurementLog.WaistCircumference,
            Chest = measurementLog.Chest,
            Arms = measurementLog.Arms,
            UserId = measurementLog.UserId
        };
    }

    public static MeasurementLog ToEntity(CreateMeasurementLogDto createMeasurementLogDto)
    {
        return new MeasurementLog
        {
            Date = createMeasurementLogDto.Date,
            Weight = createMeasurementLogDto.Weight,
            BodyFatPercentage = createMeasurementLogDto.BodyFatPercentage,
            WaistCircumference = createMeasurementLogDto.WaistCircumference,
            Chest = createMeasurementLogDto.Chest,
            Arms = createMeasurementLogDto.Arms,
            UserId = createMeasurementLogDto.UserId
        };
    }
}
