using FitnessTracker.Domain.Enums;

namespace FitnessTracker.Core.Dtos.UserDtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public DateTime RegistrationDate { get; set; }

}
