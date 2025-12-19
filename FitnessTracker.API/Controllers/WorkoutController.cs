using FitnessTracker.Core.Dtos.WorkoutDtos;
using FitnessTracker.Core.Services;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allWorkouts = await _workoutService.GetAllAsync();
            return Ok(new
            {
                Message = SuccessMessages.WorkoutsFetched,
                Data = allWorkouts
            });
        }

        [HttpGet("{workoutId:int}")]
        public async Task<IActionResult> GetById(int workoutId)
        {
            var foundWorkout = await _workoutService.GetByIdAsync(workoutId);
            if (foundWorkout == null)
            {
                return NotFound(new
                {
                    Message = string.Format(ErrorMessages.WorkoutNotFoundById, workoutId)
                });
            }

            return Ok(new
            {
                Message = SuccessMessages.WorkoutFetched,
                Data = foundWorkout
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkoutDto createWorkoutDto)
        {
            var createdWorkout = await _workoutService.CreateAsync(createWorkoutDto);

            return CreatedAtAction(nameof(GetById), new { workoutId = createdWorkout.WorkoutId }, new
            {
                Message = SuccessMessages.WorkoutCreated,
                Data = createdWorkout
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWorkoutDto updateWorkoutDto)
        {
            var updatedWorkout = await _workoutService.UpdateAsync( updateWorkoutDto);
            if (updatedWorkout == null)
            {
                return NotFound(new
                {
                    Message = string.Format(ErrorMessages.WorkoutNotFoundById)
                });
            }

            return Ok(new
            {
                Message = SuccessMessages.WorkoutUpdated,
                Data = updatedWorkout
            });
        }

        [HttpDelete("{workoutId:int}")]
        public async Task<IActionResult> Delete(int workoutId)
        {
            await _workoutService.DeleteAsync(workoutId);

            return Ok(new
            {
                Message = SuccessMessages.WorkoutDeleted
            });
        }
    }
}
