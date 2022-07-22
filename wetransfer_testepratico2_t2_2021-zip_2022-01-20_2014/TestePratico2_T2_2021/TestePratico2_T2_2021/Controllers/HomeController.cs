using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestePratico2_T2_2021.Data;
using TestePratico2_T2_2021.Models;

namespace TestePratico2_T2_2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Dishes.OrderBy(d => d.Price).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddDish()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddDish(Dish dish)
        {

            dish.User = User.Identity.Name;

            _context.Add(dish);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult MyDishes(string user)
        {

            List<Dish> dishes = _context.Dishes.Where(d => d.User.Equals(user)).ToList();

            return PartialView(dishes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
