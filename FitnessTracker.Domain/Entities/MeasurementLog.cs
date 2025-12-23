using System;
using System.Collections.Generic;

namespace FitnessTracker.Domain;

public partial class MeasurementLog
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public decimal Weight { get; set; }

    public int? BodyFatPercentage { get; set; }

    public int? WaistCircumference { get; set; }

    public int? Chest { get; set; }

    public int? Arms { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
