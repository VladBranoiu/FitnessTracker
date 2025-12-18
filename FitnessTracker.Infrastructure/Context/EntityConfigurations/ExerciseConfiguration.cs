using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__Exercise__3214EC07669775DB");

        modelBuilder
            .ToTable("Exercise");

        modelBuilder
            .HasIndex(e => e.Name, "UQ__Exercise__737584F6875675AF").IsUnique();

        modelBuilder
            .Property(e => e.DifficultyLevel)
                .HasMaxLength(10)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.MuscleGroup)
                .HasMaxLength(50)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
    }
}
