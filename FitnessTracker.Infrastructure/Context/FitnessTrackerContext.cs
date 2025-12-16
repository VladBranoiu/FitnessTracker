using System;
using System.Collections.Generic;
using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure;

public partial class FitnessTrackerContext : DbContext
{
    public FitnessTrackerContext()
    {
    }

    public FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<FoodLog> FoodLogs { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<MeasurementLog> MeasurementLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC07669775DB");

            entity.ToTable("Exercise");

            entity.HasIndex(e => e.Name, "UQ__Exercise__737584F6875675AF").IsUnique();

            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MuscleGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FoodItem__3214EC0739156FC4");

            entity.ToTable("FoodItem");

            entity.Property(e => e.Calories).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Carbs).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Fat).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Protein).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<FoodLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FoodLog__3214EC07C262DA4E");

            entity.ToTable("FoodLog");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK_FoodLog_FoodItem");

            entity.HasOne(d => d.User).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_FoodLog_User");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goal__3214EC07B8782FE5");

            entity.ToTable("Goal");

            entity.Property(e => e.GoalType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsAchieved).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Goal_User");
        });

        modelBuilder.Entity<MeasurementLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Measurem__3214EC073F30F966");

            entity.ToTable("MeasurementLog");

            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.MeasurementLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_MeasurmentLog_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C186AAC1");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053420F4947D").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workout__3214EC07F7FE31E4");

            entity.ToTable("Workout");

            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Workout_User");
        });

        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WorkoutExercise");

            entity.HasOne(d => d.Exercise).WithMany()
                .HasForeignKey(d => d.ExerciseId)
                .HasConstraintName("FK_WorkoutExercise_Exercise");

            entity.HasOne(d => d.Workout).WithMany()
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("FK_WorkoutExercise_Workout");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
