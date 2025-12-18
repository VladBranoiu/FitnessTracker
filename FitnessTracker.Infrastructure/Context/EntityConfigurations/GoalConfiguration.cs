using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__Goal__3214EC07B8782FE5");

        modelBuilder
            .ToTable("Goal");

        modelBuilder
            .Property(e => e.GoalType)
                .HasMaxLength(30)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.IsAchieved).HasDefaultValue(false);

        modelBuilder
            .HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Goal_User");
        
    }
}
