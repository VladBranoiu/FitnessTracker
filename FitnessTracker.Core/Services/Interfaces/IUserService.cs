using FitnessTracker.Core.Dtos.UserDtos;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto createUserDto);
    Task<UserDto?> UpdateAsync(int id, UpdateUserDto updateUserDto);
    Task DeleteAsync(int id);

}
