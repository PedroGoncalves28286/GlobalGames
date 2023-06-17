using GlobalGames.Data;
using GlobalGames.Data.Entities;
using GlobalGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GlobalGames.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsletterRepository _newsletterRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IUserHelper _userHelper;

        public HomeController(ILogger<HomeController> logger,
            INewsletterRepository newsletterRepository,
            IBudgetRepository budgetRepository,
            IUserHelper userHelper)
        {
            _logger = logger;
            _newsletterRepository = newsletterRepository;
            _budgetRepository = budgetRepository;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {

            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Subscrever(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                newsletter.user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _newsletterRepository.CreateAsync(newsletter);
                return RedirectToAction(nameof(Index));
            }
            return View(newsletter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Orcamento(Budget budget)
        {
            if (ModelState.IsValid)
            {
                budget.user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _budgetRepository.CreateAsync(budget);
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}