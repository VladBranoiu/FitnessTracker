using FitnessTracker.Core.Dtos.FoodItemDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class FoodItemService : IFoodItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public FoodItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<FoodItemDto>> GetAllAsync()
    {
        var items = await _unitOfWork.FoodItemRepository.GetAllAsync();
        return items.Select(FoodItemMapper.ToDto).ToList();
    }

    public async Task<FoodItemDto?> GetByIdAsync(int id)
    {
        var item = await _unitOfWork.FoodItemRepository.GetByIdAsync(id);
        return item == null ? null : FoodItemMapper.ToDto(item);
    }

    public async Task<FoodItemDto> CreateAsync(CreateFoodItemDto createFoodItemDto)
    {
        var exists = await _unitOfWork.FoodItemRepository.FindAsync(
        f => f.Name.ToLower() == createFoodItemDto.Name.ToLower()
    );

        if (exists.Any())
            throw new BadRequestException("Food item with this name already exists.");

        var entity = FoodItemMapper.ToEntity(createFoodItemDto);

        await _unitOfWork.FoodItemRepository.AddAsync(entity);
        await _unitOfWork.FoodItemRepository.SaveChangesAsync();

        return FoodItemMapper.ToDto(entity);
    }

    public async Task<bool> UpdateAsync(int id, UpdateFoodItemDto updateFoodItemDto)
    {
        var entity = await _unitOfWork.FoodItemRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        var duplicate = await _unitOfWork.FoodItemRepository.FindAsync(f =>
            f.Id != id &&
            f.Name.ToLower() == updateFoodItemDto.Name.ToLower()
        );

        if (duplicate.Any())
            throw new BadRequestException("Another food item with this name already exists.");

        FoodItemMapper.UpdateEntity(entity, updateFoodItemDto);
        await _unitOfWork.FoodItemRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _unitOfWork.FoodItemRepository.GetByIdAsync(id);
        if (entity == null)
            return false;

        _unitOfWork.FoodItemRepository.Remove(entity);
        await _unitOfWork.FoodItemRepository.SaveChangesAsync();

        return true;
    }
}
