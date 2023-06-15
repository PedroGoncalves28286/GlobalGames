using GlobalGames.Data.Entities;

namespace GlobalGames.Data
{
    public class BudgetRepository : GenericRepository<Budget>, IBudgetRepository
    {
        public BudgetRepository(DataContext context) : base(context)
        {


        }

    }
}