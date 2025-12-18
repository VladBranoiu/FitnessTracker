using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allUsers = await _userService.GetAllAsync();
        return Ok(new
        {
            Message = SuccessMessages.UsersFetched,
            Data = allUsers
        });
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetById(int userId)
    {
        var foundUser = await _userService.GetByIdAsync(userId);
        if (foundUser == null)
        {
            return NotFound(new
            {
                Message = string.Format(ErrorMessages.UserNotFoundById, userId)
            });
        }
        return Ok (new
        {
            Message = SuccessMessages.UserFetched,
            Data = foundUser
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
    {
        var createdUser = await _userService.CreateAsync(createUserDto);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, new
        {
            Message = SuccessMessages.UserCreated,
            Data = createdUser
        });
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserDto updateUserDto)
    {
        var updatedUser = await _userService.UpdateAsync(userId, updateUserDto);
        if (updatedUser == null)
        {
            return NotFound(new
            {
                Message = string.Format(ErrorMessages.UserNotFoundById, userId)
            });
        }
        return Ok(new
        {
            Message = SuccessMessages.ProfileUpdated,
            Data = updatedUser
        });
    }

    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> Delete(int userId)
    {
        await _userService.DeleteAsync(userId);
        
        return Ok(new
        {
            Message = SuccessMessages.UserDeleted
        });
    }
}
