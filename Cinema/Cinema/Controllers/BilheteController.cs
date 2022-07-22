using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class BilheteController : Controller
    {
        private readonly CinemaContext _context;

        public BilheteController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Bilhete
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Bilhete.Include(b => b.Filme);
            return View(await cinemaContext.ToListAsync());
        }

        // GET: Bilhete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Filme)
                .Include(b => b.Horario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }
        public IActionResult CreateFilme()
        {
            string id = RouteData.Values["id"].ToString();
            if (id != null)
            {
                ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", id);
                ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", id);
            }
            else
                ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome");
                ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFilme([Bind("Id,Preco,FilmeId,Lugar,HorarioId")] Bilhete bilhete)
        {
            string id = RouteData.Values["id"].ToString();
            if (ModelState.IsValid)
            {
                await _context.Bilhete.FirstOrDefaultAsync(t => t.HorarioId == bilhete.HorarioId);
                bilhete.FilmeId = int.Parse(id);
                _context.Add(bilhete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", bilhete.FilmeId);

            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", bilhete.HorarioId);
            return View(bilhete);
        }

        // GET: Bilhete/Create
        public IActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome");
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id");
            return View();
        }

        // POST: Bilhete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Preco,FilmeId,Lugar,HorarioId")] Bilhete bilhete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilhete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", bilhete.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", bilhete.HorarioId);
            return View(bilhete);
        }

        // GET: Bilhete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete.FindAsync(id);
            if (bilhete == null)
            {
                return NotFound();
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", bilhete.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", bilhete.HorarioId);
            return View(bilhete);
        }

        // POST: Bilhete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Preco,FilmeId,Lugar,HorarioId")] Bilhete bilhete)
        {
            if (id != bilhete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilhete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilheteExists(bilhete.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", bilhete.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", bilhete.HorarioId);
            return View(bilhete);
        }

        // GET: Bilhete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Filme)
                .Include(b => b.Horario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // POST: Bilhete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bilhete = await _context.Bilhete.FindAsync(id);
            _context.Bilhete.Remove(bilhete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilheteExists(int id)
        {
            return _context.Bilhete.Any(e => e.Id == id);
        }
    }
}
