using FitnessTracker.Core.Dtos.FoodItemDtos;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _foodItemService;

    public FoodItemController(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _foodItemService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _foodItemService.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFoodItemDto dto)
    {
        var created = await _foodItemService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateFoodItemDto dto)
    {
        var updated = await _foodItemService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _foodItemService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
