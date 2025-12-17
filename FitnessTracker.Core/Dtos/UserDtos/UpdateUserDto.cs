using FitnessTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Dtos.UserDtos;

public class UpdateUserDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    public DateOnly BirthDate { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Range(50, 250)]
    public decimal? Height { get; set; }

    [Range(20, 300)]
    public decimal? Weight { get; set; }
}
