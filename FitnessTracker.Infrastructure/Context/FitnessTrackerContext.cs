using System;
using System.Collections.Generic;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Context.EntityConfigurations;
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
        //configurations
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new FoodItemConfiguration());
        modelBuilder.ApplyConfiguration(new FoodLogConfiguration());
        modelBuilder.ApplyConfiguration(new GoalConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new MeasurementLogConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
