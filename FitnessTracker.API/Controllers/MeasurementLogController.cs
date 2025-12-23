using FitnessTracker.Core.Dtos.MeasurementLogDtos;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeasurementLogController : ControllerBase
{
    private readonly IMeasurementLogService _measurementLogService;

    public MeasurementLogController(IMeasurementLogService measurementLogService)
    {
        _measurementLogService = measurementLogService;
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var logs = await _measurementLogService.GetByUserIdAsync(userId);
        return Ok(logs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var log = await _measurementLogService.GetByIdAsync(id);
        return log == null ? NotFound() : Ok(log);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMeasurementLogDto dto)
    {
        var created = await _measurementLogService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMeasurementLogDto dto)
    {
        var updated = await _measurementLogService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _measurementLogService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
