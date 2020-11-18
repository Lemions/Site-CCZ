using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteCCZ.Models;
using Microsoft.AspNetCore.Authorization;

namespace SiteCCZ.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AnimaisperdidosController : Controller
    {
        private readonly Contexto _context;

        public AnimaisperdidosController(Contexto context)
        {
            _context = context;
        }

        // GET: Animaisperdidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animaisperdidos.ToListAsync());
        }

        // GET: Animaisperdidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisperdidos = await _context.Animaisperdidos
                .FirstOrDefaultAsync(m => m.IdAnimalPerdido == id);
            if (animaisperdidos == null)
            {
                return NotFound();
            }

            return View(animaisperdidos);
        }

        // GET: Animaisperdidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animaisperdidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnimalPerdido,Nome,Especie,Raca,Foto,TelefoneDono,Detalhes")] Animaisperdidos animaisperdidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animaisperdidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animaisperdidos);
        }

        // GET: Animaisperdidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisperdidos = await _context.Animaisperdidos.FindAsync(id);
            if (animaisperdidos == null)
            {
                return NotFound();
            }
            return View(animaisperdidos);
        }

        // POST: Animaisperdidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimalPerdido,Nome,Especie,Raca,Foto,TelefoneDono,Detalhes")] Animaisperdidos animaisperdidos)
        {
            if (id != animaisperdidos.IdAnimalPerdido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animaisperdidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaisperdidosExists(animaisperdidos.IdAnimalPerdido))
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
            return View(animaisperdidos);
        }

        // GET: Animaisperdidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisperdidos = await _context.Animaisperdidos
                .FirstOrDefaultAsync(m => m.IdAnimalPerdido == id);
            if (animaisperdidos == null)
            {
                return NotFound();
            }

            return View(animaisperdidos);
        }

        // POST: Animaisperdidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animaisperdidos = await _context.Animaisperdidos.FindAsync(id);
            _context.Animaisperdidos.Remove(animaisperdidos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimaisperdidosExists(int id)
        {
            return _context.Animaisperdidos.Any(e => e.IdAnimalPerdido == id);
        }
    }
}
