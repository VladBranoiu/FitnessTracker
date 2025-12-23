using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public MuscleGroup MuscleGroup { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; }
}
