using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly CinemaContext _context;

        public HistoricoController(CinemaContext context)
        {
            _context = context;
        }


        // GET: Historico
        public async Task<IActionResult> Index()
        {
            var cinemaContext =  _context.Historico.Include(h => h.Filme).Include(h => h.Perfil).Where(d => d.Perfil.Username.Equals(User.Identity.Name));


            return View(await cinemaContext.ToListAsync());
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .Include(h => h.Filme)
                .Include(h => h.Perfil)
                .FirstOrDefaultAsync(m => m.FilmeId == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        [Authorize(Roles = "Administrador, Funcionário")]
        // GET: Historico/Create
        public IActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome");
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Username");
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador, Funcionário")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmeId,PerfilId")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", historico.FilmeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Username", historico.PerfilId);
            return View(historico);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", historico.FilmeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Username", historico.PerfilId);
            return View(historico);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmeId,PerfilId")] Historico historico)
        {
            if (id != historico.FilmeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoExists(historico.FilmeId))
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
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "Id", "Nome", historico.FilmeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Username", historico.PerfilId);
            return View(historico);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .Include(h => h.Filme)
                .Include(h => h.Perfil)
                .FirstOrDefaultAsync(m => m.FilmeId == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historico = await _context.Historico.FindAsync(id);
            _context.Historico.Remove(historico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.FilmeId == id);
        }
    }
}
