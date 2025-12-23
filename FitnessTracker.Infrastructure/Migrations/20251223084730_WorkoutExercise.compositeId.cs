using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutExercisecompositeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercise_WorkoutId",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkoutExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise",
                columns: new[] { "WorkoutId", "ExerciseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkoutExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_WorkoutId",
                table: "WorkoutExercise",
                column: "WorkoutId");
        }
    }
}
