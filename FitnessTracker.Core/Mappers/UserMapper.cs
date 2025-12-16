using FitnessTracker.Core.Dtos.UserDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class UserMapper
{
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
            Gender = user.Gender,
            Height = user.Height,
            Weight = user.Weight,
            RegistrationDate = user.RegistrationDate
        };
    }

    public static User ToEntity(CreateUserDto createUserDto)
    {
        return new User
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            BirthDate = createUserDto.BirthDate,
            Gender = createUserDto.Gender,
            Height = createUserDto.Height,
            Weight = createUserDto.Weight,
            RegistrationDate = DateOnly.FromDateTime(DateTime.UtcNow.Date)

        };
    }
    public static void UpdateEntity(User user, UpdateUserDto updateUserDto)
    {
        user.Name = updateUserDto.Name;
        user.Email = updateUserDto.Email;
        user.BirthDate = updateUserDto.BirthDate;
        user.Gender = updateUserDto.Gender;
        user.Height = updateUserDto.Height;
        user.Weight = updateUserDto.Weight;
    }
}
