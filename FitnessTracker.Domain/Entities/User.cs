using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public Gender Gender { get; set; }

    public decimal Height { get; set; }

    public decimal Weight { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<FoodLog> FoodLogs { get; set; } = new List<FoodLog>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<MeasurementLog> MeasurementLogs { get; set; } = new List<MeasurementLog>();

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
