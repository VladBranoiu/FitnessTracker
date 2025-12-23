using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class FoodLog
{
    public int Id { get; set; }

    public DateOnly LogDate { get; set; }

    public int Servings { get; set; }

    public int Quantity { get; set; }

    public int UserId { get; set; }

    public int FoodId { get; set; }

    public virtual FoodItem? Food { get; set; }

    public virtual User? User { get; set; }
}
