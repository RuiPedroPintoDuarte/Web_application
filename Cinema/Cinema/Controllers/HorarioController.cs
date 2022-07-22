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
    public class HorarioController : Controller
    {
        private readonly CinemaContext _context;

        public HorarioController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Horario
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Horario.Include(h => h.Filme).Include(h => h.Sala);
            return View(await cinemaContext.ToListAsync());
        }

        // GET: Horario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Filme)
                .Include(h => h.Sala)
                .FirstOrDefaultAsync(m => m.SalaId == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horario/Create
        public IActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome");
            ViewData["SalaId"] = new SelectList(_context.Sala, "Numero", "Numero");
            return View();
        }

        // POST: Horario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmeId,Dia,Hora,SalaId")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", horario.FilmeId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Numero", "Numero", horario.SalaId);
            return View(horario);
        }

        // GET: Horario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", horario.FilmeId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Numero", "Numero", horario.SalaId);
            return View(horario);
        }

        // POST: Horario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmeId,Dia,Hora,SalaId")] Horario horario)
        {
            if (id != horario.SalaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.SalaId))
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
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", horario.FilmeId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Numero", "Numero", horario.SalaId);
            return View(horario);
        }

        // GET: Horario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Filme)
                .Include(h => h.Sala)
                .FirstOrDefaultAsync(m => m.SalaId == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.SalaId == id);
        }
    }
}
