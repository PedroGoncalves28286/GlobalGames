using GlobalGames.Data.Entities;

namespace GlobalGames.Data
{
    public class NewsletterRepository : GenericRepository<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(DataContext context) : base(context)
        {

        }
    }
}