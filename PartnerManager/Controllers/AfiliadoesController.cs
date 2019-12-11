using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartnerManager.Data;
using PartnerManager.Models;

namespace PartnerManager.Controllers
{
    public class AfiliadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfiliadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Afiliadoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Afiliados.Include(a => a.Socio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Afiliadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .Include(a => a.Socio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // GET: Afiliadoes/Create
        public IActionResult Create()
        {
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id");
            return View();
        }

        // POST: Afiliadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,SocioId,Relacion")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afiliado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", afiliado.SocioId);
            return View(afiliado);
        }

        // GET: Afiliadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", afiliado.SocioId);
            return View(afiliado);
        }

        // POST: Afiliadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,SocioId,Relacion")] Afiliado afiliado)
        {
            if (id != afiliado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afiliado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfiliadoExists(afiliado.Id))
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
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", afiliado.SocioId);
            return View(afiliado);
        }

        // GET: Afiliadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .Include(a => a.Socio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // POST: Afiliadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afiliado = await _context.Afiliados.FindAsync(id);
            _context.Afiliados.Remove(afiliado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfiliadoExists(int id)
        {
            return _context.Afiliados.Any(e => e.Id == id);
        }
    }
}
