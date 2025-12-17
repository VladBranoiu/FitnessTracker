using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__Workout__3214EC07F7FE31E4");

        modelBuilder
            .ToTable("Workout");

        modelBuilder
            .Property(e => e.Notes)
            .HasMaxLength(255)
            .IsUnicode(false);

        modelBuilder
            .HasOne(d => d.User).WithMany(p => p.Workouts)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Workout_User");
    }
}
