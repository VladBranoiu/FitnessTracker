using FitnessTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Dtos.UserDtos;

public class UpdateUserDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}
