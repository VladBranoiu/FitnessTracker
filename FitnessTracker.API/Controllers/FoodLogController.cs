using FitnessTracker.Core.Dtos.FoodLogDtos;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodLogController : ControllerBase
{

    private readonly IFoodLogService _foodLogService;

    public FoodLogController(IFoodLogService foodLogService)
    {
        _foodLogService = foodLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _foodLogService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var log = await _foodLogService.GetByIdAsync(id);
        return log == null ? NotFound() : Ok(log);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUser(int userId)
        => Ok(await _foodLogService.GetByUserIdAsync(userId));

    [HttpPost]
    public async Task<IActionResult> Create(CreateFoodLogDto dto)
    {
        var created = await _foodLogService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateFoodLogDto dto)
    {
        var updated = await _foodLogService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _foodLogService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
