using Exame2021.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Exame2021.Data;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace Exame2021.Controllers
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
            var Context = _context.Documento.Include(c => c.Downloads);
            return View(Context);
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

        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(string Titulo, IFormFile Nome)
        {
            if (ModelState.IsValid == false)
                return View();
            _context.Add(new Documento()
            {
                Nome = Nome.FileName,
                Titulo = Titulo,
            });
            string Destination = Path.Combine(_he.ContentRootPath, "wwwroot\\Docs\\", Path.GetFileName(Nome.FileName));
            FileStream fs = new FileStream(Destination, FileMode.Create);
            Nome.CopyTo(fs);
            _context.SaveChanges();
            fs.Close();
            return RedirectToAction("Index");
        }
        public IActionResult Download(int id)
        {
            var file = _context.Documento.FirstOrDefault(c => c.Id == id);
            if (file == null)
                return RedirectToAction("Index");
            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Docs/", file.Nome);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);

            string mimetype;

            new FileExtensionContentTypeProvider().TryGetContentType(file.Nome, out mimetype);
            _context.Add(new Download()
            {
                Data = DateTime.Now,
                Utilizador = User.Identity.Name,
                Documento = file,
                DocumentoID = file.Id
            });
            _context.SaveChanges();

            return File(fileBytes, mimetype);

        }
        public IActionResult Down()
        {
            return PartialView("Down",null);
        }
        [HttpPost]
        public IActionResult Down(string id)
        {

            var list = _context.Download.Include(c => c.Documento).ToList();
            var found = list.FindAll(c => c.Utilizador == id);
            var retVal = found.OrderBy(c => c.Data.TimeOfDay).ThenBy(c => c.Data.Date).ThenBy(x => x.Data.Year);
            return PartialView("Down", retVal);
        }
    }
}
