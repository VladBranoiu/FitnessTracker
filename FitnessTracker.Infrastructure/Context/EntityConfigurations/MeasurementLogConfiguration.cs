using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class MeasurementLogConfiguration : IEntityTypeConfiguration<MeasurementLog>
{
    public void Configure(EntityTypeBuilder<MeasurementLog> modelBuilder)
    {
        modelBuilder
            .HasKey(e => e.Id).HasName("PK__Measurem__3214EC073F30F966");

        modelBuilder
            .ToTable("MeasurementLog");

        modelBuilder
            .Property(e => e.Weight).HasColumnType("decimal(5, 2)");

        modelBuilder
            .HasOne(d => d.User).WithMany(p => p.MeasurementLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_MeasurmentLog_User");
    }
}
