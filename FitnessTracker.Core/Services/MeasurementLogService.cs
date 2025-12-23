using FitnessTracker.Core.Dtos.MeasurementLogDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class MeasurementLogService : IMeasurementLogService
{
    private const decimal MaxKgPerDay = 1;

    private readonly IRepository<MeasurementLog> _measurementRepository;
    private readonly IUserRepository _userRepository;

    public MeasurementLogService(IRepository<MeasurementLog> measurementRepository, IUserRepository userRepository)
    {
        _measurementRepository = measurementRepository;
        _userRepository = userRepository;
    }

    public async Task<List<MeasurementLogDto>> GetByUserIdAsync(int userId)
    {
        var logs = await _measurementRepository.FindAsync(x => x.UserId == userId);
        return logs
            .OrderByDescending(x => x.Date)
            .Select(MeasurementLogMapper.ToDto)
            .ToList();
    }

    public async Task<MeasurementLogDto?> GetByIdAsync(int id)
    {
        var log = await _measurementRepository.GetByIdAsync(id);
        return log == null ? null : MeasurementLogMapper.ToDto(log);
    }

    public async Task<MeasurementLogDto> CreateAsync(CreateMeasurementLogDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user == null)
            throw new NotFoundException("User not found.");

        
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        if (dto.Date > today)
            throw new BadRequestException("Date can't be in the future.");

        await ValidateMaxWeightChangePerDay(dto.UserId, dto.Date, dto.Weight, excludeMeasurementId: null);

        var entity = MeasurementLogMapper.ToEntity(dto);
        await _measurementRepository.AddAsync(entity);
        await _measurementRepository.SaveChangesAsync();

        return MeasurementLogMapper.ToDto(entity);
    }

    public async Task<bool> UpdateAsync(int id, UpdateMeasurementLogDto dto)
    {
        var entity = await _measurementRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        if (entity.UserId == null)
            throw new BadRequestException("MeasurementLog has no UserId associated.");

        var userId = entity.UserId.Value;

        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        if (dto.Date > today)
            throw new BadRequestException("Date can't be in the future.");

        await ValidateMaxWeightChangePerDay(userId, dto.Date, dto.Weight, excludeMeasurementId: id);

        MeasurementLogMapper.UpdateEntity(entity, dto);

        await _measurementRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _measurementRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        _measurementRepository.Remove(entity);
        await _measurementRepository.SaveChangesAsync();
        return true;
    }

    private async Task ValidateMaxWeightChangePerDay(int userId, DateOnly newDate, decimal newWeight, int? excludeMeasurementId)
    {
        var logs = await _measurementRepository.FindAsync(m => m.UserId == userId);

        var filtered = excludeMeasurementId.HasValue
            ? logs.Where(x => x.Id != excludeMeasurementId.Value)
            : logs;

        var previous = filtered
            .OrderByDescending(x => x.Date)
            .FirstOrDefault();

        if (previous?.Date == null)
            return; 

        var prevWeight = Convert.ToDecimal(previous.Weight);

        var days = (newDate.ToDateTime(TimeOnly.MinValue) - previous.Date.ToDateTime(TimeOnly.MinValue)).TotalDays;
        if (days <= 0)
            return; 

        var kgPerDay = Math.Abs(newWeight - prevWeight) / (decimal)days;

        if (kgPerDay > MaxKgPerDay)
        {
            throw new BadRequestException($"Weight change exceeds {MaxKgPerDay} kg/day. Please verify the entry.");
        }
    }
}
