using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutExerciseController : ControllerBase
{
    private readonly IWorkoutExerciseService _workoutExerciseService;

    public WorkoutExerciseController(IWorkoutExerciseService workoutExerciseService)
    {
        _workoutExerciseService = workoutExerciseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<WorkoutExerciseDto>>> Get(int userId, int workoutId)
       => Ok(await _workoutExerciseService.GetByWorkoutIdAsync(userId, workoutId));

    [HttpPost]
    public async Task<ActionResult<WorkoutExerciseDto>> Create(int userId, int workoutId, [FromBody] CreateWorkoutExerciseDto dto)
        => Ok(await _workoutExerciseService.CreateAsync(userId, workoutId, dto));

    [HttpPut("{workoutExerciseId:int}")]
    public async Task<ActionResult<WorkoutExerciseDto>> Update(int userId, int workoutId, int workoutExerciseId, [FromBody] UpdateWorkoutExerciseDto dto)
        => Ok(await _workoutExerciseService.UpdateAsync(userId, workoutId, workoutExerciseId, dto));

    [HttpDelete("{workoutExerciseId:int}")]
    public async Task<IActionResult> Delete(int userId, int workoutId, int workoutExerciseId)
    {
        await _workoutExerciseService.DeleteAsync(userId, workoutId, workoutExerciseId);
        return NoContent();
    }
}
