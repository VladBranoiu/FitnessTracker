using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class WorkoutExercise
{
    public int Sets { get; set; }

    public int Reps { get; set; }

    public int WeightUsed { get; set; }

    public int WorkoutId { get; set; }

    public int ExerciseId { get; set; }

    public virtual Exercise? Exercise { get; set; }

    public virtual Workout? Workout { get; set; }
}
