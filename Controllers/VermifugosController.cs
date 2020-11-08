using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SiteCCZ.Models;

namespace SiteCCZ.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class VermifugosController : Controller
    {
        private readonly Contexto _context;

        public VermifugosController(Contexto context)
        {
            _context = context;
        }

        // GET: Vermifugos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vermifugos.ToListAsync());
        }

        // GET: Vermifugos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vermifugos = await _context.Vermifugos
                .FirstOrDefaultAsync(m => m.IdVermifugo == id);
            if (vermifugos == null)
            {
                return NotFound();
            }

            return View(vermifugos);
        }

        // GET: Vermifugos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vermifugos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVermifugo,Nome,Periodicidade")] Vermifugos vermifugos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vermifugos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vermifugos);
        }

        // GET: Vermifugos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vermifugos = await _context.Vermifugos.FindAsync(id);
            if (vermifugos == null)
            {
                return NotFound();
            }
            return View(vermifugos);
        }

        // POST: Vermifugos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVermifugo,Nome,Periodicidade")] Vermifugos vermifugos)
        {
            if (id != vermifugos.IdVermifugo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vermifugos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VermifugosExists(vermifugos.IdVermifugo))
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
            return View(vermifugos);
        }

        // GET: Vermifugos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vermifugos = await _context.Vermifugos
                .FirstOrDefaultAsync(m => m.IdVermifugo == id);
            if (vermifugos == null)
            {
                return NotFound();
            }

            return View(vermifugos);
        }

        // POST: Vermifugos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vermifugos = await _context.Vermifugos.FindAsync(id);
            _context.Vermifugos.Remove(vermifugos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VermifugosExists(int id)
        {
            return _context.Vermifugos.Any(e => e.IdVermifugo == id);
        }
    }
}
