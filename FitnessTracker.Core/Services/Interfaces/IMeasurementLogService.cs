using FitnessTracker.Core.Dtos.MeasurementLogDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IMeasurementLogService
{
    Task<List<MeasurementLogDto>> GetByUserIdAsync(int userId);
    Task<MeasurementLogDto?> GetByIdAsync(int id);
    Task<MeasurementLogDto> CreateAsync(CreateMeasurementLogDto createMeasurementLogDto);
    Task<bool> UpdateAsync(int id, UpdateMeasurementLogDto updateMeasurementLogDto);
    Task<bool> DeleteAsync(int id);
}
