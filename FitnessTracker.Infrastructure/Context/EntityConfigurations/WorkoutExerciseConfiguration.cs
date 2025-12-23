using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> modelBuilder)
    {
        modelBuilder.Property(workoutExercise => workoutExercise.WeightUsed)
             .HasPrecision(5, 2);

        modelBuilder
             .HasNoKey()
             .ToTable("WorkoutExercise");

        modelBuilder.HasOne(d => d.Exercise).WithMany()
            .HasForeignKey(d => d.ExerciseId)
            .HasConstraintName("FK_WorkoutExercise_Exercise");

        modelBuilder.HasOne(d => d.Workout).WithMany()
            .HasForeignKey(d => d.WorkoutId)
            .HasConstraintName("FK_WorkoutExercise_Workout");
    }
}
