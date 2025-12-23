using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class FoodLogConfiguration : IEntityTypeConfiguration<FoodLog>
{
    public void Configure(EntityTypeBuilder<FoodLog> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__FoodLog__3214EC07C262DA4E");

        modelBuilder
            .ToTable("FoodLog");

        modelBuilder
            .HasOne(d => d.Food).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK_FoodLog_FoodItem");

        modelBuilder
            .HasOne(d => d.User).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_FoodLog_User");
    }
}
