using FitnessTracker.Core.Dtos.ExerciseDtos;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allExercises = await _exerciseService.GetAllAsync();
        return Ok(new
        {
            Message = SuccessMessages.ExercisesFetched,
            Data = allExercises
        });
    }

    [HttpGet("{exerciseId:int}")]
    public async Task<IActionResult> GetById(int exerciseId)
    {
        var foundExercise = await _exerciseService.GetByIdAsync(exerciseId);
        if (foundExercise == null)
        {
            return NotFound(new
            {
                Message = string.Format(ErrorMessages.ExerciseNotFoundById, exerciseId)
            });
        }

        return Ok(new
        {
            Message = SuccessMessages.ExerciseFetched,
            Data = foundExercise
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExerciseDto createExerciseDto)
    {
        var createdExercise = await _exerciseService.CreateAsync(createExerciseDto);

        return CreatedAtAction(nameof(GetById), new { exerciseId = createdExercise.Id }, new
        {
            Message = SuccessMessages.ExerciseCreated,
            Data = createdExercise
        });
    }

    [HttpPut("{exerciseId:int}")]
    public async Task<IActionResult> Update(int exerciseId, [FromBody] UpdateExerciseDto updateExerciseDto)
    {
        var updatedExercise = await _exerciseService.UpdateAsync(exerciseId, updateExerciseDto);
        if (updatedExercise == null)
        {
            return NotFound(new
            {
                Message = string.Format(ErrorMessages.ExerciseNotFoundById, exerciseId)
            });
        }

        return Ok(new
        {
            Message = SuccessMessages.ExerciseUpdated,
            Data = updatedExercise
        });
    }

    [HttpDelete("{exerciseId:int}")]
    public async Task<IActionResult> Delete(int exerciseId)
    {
        await _exerciseService.DeleteAsync(exerciseId);

        return Ok(new
        {
            Message = SuccessMessages.ExerciseDeleted
        });
    }
}
