using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Infrastructure.Constants;
using FitnessTracker.Infrastructure.Exceptions;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Core.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        return users.Select(UserMapper.ToDto);
    }

    public async Task<UserDto?> GetByIdAsync(int userId)
    {
       var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

       if (user is null)
       {
          throw new NotFoundException(string.Format(ErrorMessages.UserNotFoundById, userId));
       }
        return UserMapper.ToDto(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
    {
        if (await _unitOfWork.UserRepository.ExistsByEmailAsync(createUserDto.Email))
        {
            throw new BadRequestException(ErrorMessages.EmailAlreadyExists);
        }
        var user = UserMapper.ToEntity(createUserDto);

        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.UserRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }

    public async Task<UserDto?> UpdateAsync(int userId, UpdateUserDto updateUserDto)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.UserNotFoundById, userId));
        }

        if (await _unitOfWork.UserRepository.ExistsByEmailAsync(user.Email))
        {
            var errors = new Dictionary<string, List<string>>
            {
                { nameof(updateUserDto.Email), new() { ErrorMessages.EmailAlreadyExists } }
            };
        }

        UserMapper.UpdateEntity(user, updateUserDto);

        await _unitOfWork.UserRepository.SaveChangesAsync();

        return UserMapper.ToDto(user);
    }

    public async Task DeleteAsync(int userId)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.UserNotFoundById, userId)); ;
        }

        _unitOfWork.UserRepository.Remove(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
