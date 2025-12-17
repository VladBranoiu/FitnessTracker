using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Context.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {

        modelBuilder
            .HasKey(e => e.Id).HasName("PK__Users__3214EC07C186AAC1");

        modelBuilder
            .HasIndex(e => e.Email, "UQ__Users__A9D1053420F4947D").IsUnique();

        modelBuilder
            .Property(e => e.Email).HasMaxLength(50);

        modelBuilder
            .Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.Height).HasColumnType("decimal(5, 2)");

        modelBuilder
            .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

        modelBuilder
            .Property(e => e.Weight).HasColumnType("decimal(5, 2)");
        

        modelBuilder.HasIndex(user => user.Name).IsUnique();
        modelBuilder.HasIndex(user => user.Email).IsUnique();

        modelBuilder.Property(user => user.Name).IsRequired().HasMaxLength(50);
        modelBuilder.Property(user => user.Email).IsRequired().HasMaxLength(50);

        modelBuilder.Property(user => user.Gender).HasConversion<string>().HasMaxLength(8);

        modelBuilder.ToTable(table =>
        {
            table.HasCheckConstraint("CK_Users_Email_Format", "[Email] LIKE '%_@__%.__%'");
            table.HasCheckConstraint("CK_Users_BirthDate", "[BirthDate] <= GETDATE()");
            table.HasCheckConstraint("CK_Users_Height", "[Height] BETWEEN 50 AND 250");
            table.HasCheckConstraint("CK_Users_Weight", "[Weight] BETWEEN 20 AND 300");
        });
    }
}

