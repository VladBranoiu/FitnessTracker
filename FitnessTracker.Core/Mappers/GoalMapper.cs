using FitnessTracker.Core.Dtos.GoalDtos;
using FitnessTracker.Domain;

namespace FitnessTracker.Core.Mappers;

public class GoalMapper
{
        public static GoalDto ToDto(Goal goal)
        {
            return new GoalDto
            {
                Id = goal.Id,
                GoalType = goal.GoalType,
                TargetValue = goal.TargetValue,
                StartDate = goal.StartDate,
                EndDate = goal.EndDate,
                IsAchieved = goal.IsAchieved,
                UserId = goal.UserId
            };
        }

        public static Goal ToEntity(CreateGoalDto createGoalDto)
        {
            return new Goal
            {
                GoalType = createGoalDto.GoalType,
                TargetValue = createGoalDto.TargetValue,
                StartDate = createGoalDto.StartDate,
                EndDate = createGoalDto.EndDate,
                UserId = createGoalDto.UserId,
                IsAchieved = false
            };
        }

        public static void UpdateEntity(Goal goal, UpdateGoalDto updateGoalDto)
        {
            goal.GoalType = updateGoalDto.GoalType;
            goal.TargetValue = updateGoalDto.TargetValue;
            goal.StartDate = updateGoalDto.StartDate;
            goal.EndDate = updateGoalDto.EndDate;
        }
}
