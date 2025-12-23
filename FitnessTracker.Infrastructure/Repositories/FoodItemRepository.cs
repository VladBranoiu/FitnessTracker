using FitnessTracker.Domain;
using FitnessTracker.Infrastructure.Repositories.Interfaces;

namespace FitnessTracker.Infrastructure.Repositories;

public class FoodItemRepository : Repository<FoodItem>, IFoodItemRepository
{
    public FoodItemRepository(FitnessTrackerContext context) : base(context)
    {

    }
}
