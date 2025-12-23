using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MuscleGroup { get; set; }

    public string? DifficultyLevel { get; set; }
}
