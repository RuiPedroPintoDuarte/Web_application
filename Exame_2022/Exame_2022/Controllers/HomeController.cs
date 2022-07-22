using Exame_2022.Data;
using Exame_2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exame_2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he;
        private readonly ApplicationDbContext _context;
        

        public HomeController(ILogger<HomeController> logger, IHostEnvironment he, ApplicationDbContext context)
        {
            _logger = logger;
            _he = he;
            _context = context;
        }
        
        public IActionResult Index()
        {
            
            return View(_context.Empresas.Include(c => c.Pais).OrderByDescending(x => x.PaisID));
            
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

        public IActionResult Registo()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Registo(string nome, IFormFile Logotipo, string paisID)
        {
            
            if (ModelState.IsValid == false)
                return View();
            _context.Add(new Empresa()
            {
                Logotipo = Logotipo.FileName,
                Nome = nome,
                PaisID=paisID,
            });
            string Destination = Path.Combine(_he.ContentRootPath, "wwwroot\\Logos\\", Path.GetFileName(Logotipo.FileName));
            FileStream fs = new FileStream(Destination, FileMode.Create);
            Logotipo.CopyTo(fs);
            _context.SaveChanges();
            fs.Close();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public string Apagar(int id)
        {

            _context.Remove(new Empresa()
            {
                Id = id
            }); ;


            _context.SaveChanges();
            return "";
        }

    }
}
