using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pap2B.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Pap2B.Data;
using Microsoft.EntityFrameworkCore;

namespace Pap2B.Controllers
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
            return View(_context.Filmes.OrderByDescending(p => p.Pontuaçao).ToList());
        }
        public IActionResult AddFilme()
        {
            return View();
        }
        [HttpPost]
      
        public IActionResult AddFilme(Filme filme)
        {

            if (filme != null)
            {
                filme.Pontuaçao = 5;
                filme.Titulo = "Titanic" ;

                _context.Add(filme);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            else return RedirectToAction("Index");

        }
/*
        public async Task<string> AddPontuacao(int id)
        {
            var post = await _context.Filmes.SingleOrDefaultAsync(x => x.Id == id);

            post.Pontuaçao += 1;

            _context.Update(filme);
            await _context.SaveChangesAsync();

            return post.Pontuaçao.ToString();
        }
*/
        public IActionResult Privacy()
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
