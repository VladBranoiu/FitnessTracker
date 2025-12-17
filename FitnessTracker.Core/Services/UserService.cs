using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Repositories;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
    {
       var user = UserMapper.ToEntity(createUserDto);

        if (await _userRepository.ExistsByEmailAsync(user.Email))
        {
            var errors = new Dictionary<string, List<string>>
            {
                { nameof(createUserDto.Email), new() { "Email already exists." } }
            };
            //throw new ValidationException(errors);
        }

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        _userRepository.Remove(user);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserMapper.ToDto);
    }

    public async Task<UserDto?> GetByIdAsync(int userId)
    {
       var user = await _userRepository.GetByIdAsync(userId);
       return user == null ? null : UserMapper.ToDto(user);
    }

    public async Task<UserDto?> UpdateAsync(int userId, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return null;

        UserMapper.UpdateEntity(user, updateUserDto);

        if (await _userRepository.ExistsByEmailAsync(user.Email))
        {
            var errors = new Dictionary<string, List<string>>
            {
                { nameof(updateUserDto.Email), new() { "Email already exists." } }
            };
            //throw new ValidationException(errors);
        }

        await _userRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }
}
