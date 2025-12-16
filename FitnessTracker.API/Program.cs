using FitnessTracker.Core.Mappers;
using FitnessTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FitnessTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(_ => { },
    typeof(UserMapper), 
    typeof(WorkoutMapper),
    typeof(ExerciseMapper),
    typeof(GoalMapper), 
    typeof(WorkoutExerciseMapper), 
    typeof(FoodItemMapper)
);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();