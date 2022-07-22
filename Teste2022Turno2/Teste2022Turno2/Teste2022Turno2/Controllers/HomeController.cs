using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teste2022Turno2.Models;
using Teste2022Turno2.Data;

namespace Teste2022Turno2.Controllers
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
            var retVal = _context.Filme.OrderByDescending(c => c.Pontuaçao);
            return View(retVal);
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

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Titulo)
        {
            if(User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Index");
            }
            var found = _context.Filme.FirstOrDefault(x => x.Titulo == Titulo); //found usado para ver se existe um título igual se existir vai recarrega a mesma página
            if (found != null)
                return View();
            _context.Add(new Filme() { Titulo = Titulo, Pontuaçao = 0 });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public int Gosto(int id)
        {
            var found = _context.Filme.FirstOrDefault(x => x.Id == id);
            found.Pontuaçao++;
            _context.SaveChanges();
            return found.Pontuaçao;
        }
        [HttpPost]
        public int Nao_Gosto(int id)
        {
            var found = _context.Filme.FirstOrDefault(x => x.Id == id);
            found.Pontuaçao--;
            _context.SaveChanges();
            return found.Pontuaçao;
        }
    }
}
