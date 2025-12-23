using FitnessTracker.Core.Dtos.WorkoutExerciseDtos;
using FitnessTracker.Core.Services;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
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

    [HttpGet("{workoutId:int}")]
    public async Task<IActionResult> GetAll(int workoutId)
    {
        var allWorkouts = await _workoutExerciseService.GetAllByWorkoutIdAsync(workoutId);
        return Ok(new
        {
            Message = SuccessMessages.WorkoutsFetched,
            Data = allWorkouts
        });
    }
    [HttpGet]
    public async Task<ActionResult<WorkoutExerciseDto>> Get(int exerciseId, int workoutId)
       => Ok(await _workoutExerciseService.GetByWorkoutAndExerciseIdsAsync(exerciseId, workoutId));

    [HttpPost]
    public async Task<ActionResult<WorkoutExerciseDto>> Create([FromBody] CreateWorkoutExerciseDto dto)
        => Ok(await _workoutExerciseService.CreateAsync( dto));

    [HttpPut]
    public async Task<ActionResult<WorkoutExerciseDto>> Update([FromBody] UpdateWorkoutExerciseDto dto)
        => Ok(await _workoutExerciseService.UpdateAsync( dto));

    [HttpDelete]
    public async Task<IActionResult> Delete(int workoutId, int exerciseId)
    {
        await _workoutExerciseService.DeleteAsync(workoutId, exerciseId);
        return NoContent();
    }
}
