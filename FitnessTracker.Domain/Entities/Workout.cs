using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class Workout
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public DateTime Date { get; set; }

    public int DurationInMinutes { get; set; }

    public string? Notes { get; set; }

    public int UserId { get; set; }

    public virtual User? User { get; set; }
}
