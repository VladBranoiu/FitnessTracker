using FitnessTracker.Core.Dtos.GoalDtos;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoalsController : ControllerBase
{
    private readonly IGoalService _goalService;

    public GoalsController(IGoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _goalService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var goal = await _goalService.GetByIdAsync(id);
        return goal == null ? NotFound() : Ok(goal);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUser(int userId)
        => Ok(await _goalService.GetByUserIdAsync(userId));

    [HttpPost]
    public async Task<IActionResult> Create(CreateGoalDto dto)
    {
        var createdGoal = await _goalService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdGoal.Id }, createdGoal);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateGoalDto dto)
    {
        var updated = await _goalService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _goalService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
