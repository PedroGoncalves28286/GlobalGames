using GlobalGames.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalGames.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<Budget> Budgets { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

    }
}