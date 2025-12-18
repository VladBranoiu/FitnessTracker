using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories;
using FitnessTracker.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserMapper.ToDto);
    }

    public async Task<UserDto?> GetByIdAsync(int userId)
    {
       var user = await _userRepository.GetByIdAsync(userId);

       if (user is null)
       {
          throw new NotFoundException(ErrorMessages.UserNotFoundById);
       }
        return UserMapper.ToDto(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
    {
        if (await _userRepository.ExistsByEmailAsync(createUserDto.Email))
        {
            throw new BadRequestException(ErrorMessages.EmailAlreadyExists);
        }
        var user = UserMapper.ToEntity(createUserDto);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }

    public async Task<UserDto?> UpdateAsync(int userId, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException(ErrorMessages.UserNotFoundById);
        }

        if (await _userRepository.ExistsByEmailAsync(user.Email))
        {
            var errors = new Dictionary<string, List<string>>
            {
                { nameof(updateUserDto.Email), new() { ErrorMessages.EmailAlreadyExists } }
            };
        }

        UserMapper.UpdateEntity(user, updateUserDto);

        await _userRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }

    public async Task DeleteAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException(ErrorMessages.UserNotFoundById);
        }

        _userRepository.Remove(user);
        await _userRepository.SaveChangesAsync();
    }
}
