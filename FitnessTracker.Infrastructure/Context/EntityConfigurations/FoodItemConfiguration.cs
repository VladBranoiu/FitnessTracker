using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class FoodItemConfiguration : IEntityTypeConfiguration<FoodItem>
{
    public void Configure(EntityTypeBuilder<FoodItem> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__FoodItem__3214EC0739156FC4");

        modelBuilder
            .ToTable("FoodItem");

        modelBuilder
            .Property(e => e.Calories).HasColumnType("decimal(6, 2)");

        modelBuilder
            .Property(e => e.Carbs).HasColumnType("decimal(6, 2)");

        modelBuilder
            .Property(e => e.Fat).HasColumnType("decimal(6, 2)");

        modelBuilder
            .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.Protein).HasColumnType("decimal(6, 2)");
        
    }
}
