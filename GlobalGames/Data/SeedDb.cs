using GlobalGames.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGames.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("daia_farias@hotmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Daiane",
                    LastName = "Farias",
                    Email = "daia_farias@hotmail.com",
                    UserName = "daia_farias@hotmail.com",

                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

            }
            if (!_context.Newsletters.Any())
            {
                AddNewsletter("daia_farias@hotmail.com", user);
                await _context.SaveChangesAsync();
            }
            if (!_context.Budgets.Any())
            {
                AddBudget("Daiane Farias", user);
                await _context.SaveChangesAsync();
            }

        }

        private void AddBudget(string name, User user)
        {
            _context.Budgets.Add(new Budget
            {
                Nome = name,
                Email = user.Email,
                Mensagem = user.Email,
                user = user


            });

        }

        private void AddNewsletter(string email, User user)
        {
            _context.Newsletters.Add(new Newsletter
            {
                Email = email,
                user = user,
            });
        }
    }

}