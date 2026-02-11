using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class Goal
{
    public int Id { get; set; }

    public string? GoalType { get; set; }

    public int? TargetValue { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsAchieved { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
