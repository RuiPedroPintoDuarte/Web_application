using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teste2022Turno1.Models;
using Teste2022Turno1.Data;
using Microsoft.AspNetCore.Http;

namespace Teste2022Turno1.Controllers
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
            var list = _context.Filmes.ToList().FindAll(x => x.Estado == true).OrderByDescending(x=>x.Duração);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddFilme()
        {
            if (User.Identity.IsAuthenticated == false)
                return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult AddFilme(string Titulo, int Duração)
        {
            if (User.Identity.IsAuthenticated == false)
                return RedirectToAction("Index");
            _context.Add(new Filme() { Titulo = Titulo, Duração = Duração });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string Delete(int id)
        {
            if (User.Identity.IsAuthenticated == false)
                return null;
            var val = Request.Cookies["alreadyDeleted"];
            if (val != null)
            {
                return null;
            }


            HttpContext.Response.Cookies.Append("alreadyDeleted", User.Identity.Name,
                new CookieOptions() { Expires = DateTime.Now.AddMinutes(5) });
            var delete = _context.Filmes.FirstOrDefault(c=>c.Id == id);
            delete.Estado = false;
            _context.SaveChanges();
            return "";
        }
    }
}
