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
    public class AnimaisachadosController : Controller
    {
        private readonly Contexto _context;

        public AnimaisachadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Animaisachados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animaisachados.ToListAsync());
        }

        // GET: Animaisachados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisachados = await _context.Animaisachados
                .FirstOrDefaultAsync(m => m.IdAnimalAchado == id);
            if (animaisachados == null)
            {
                return NotFound();
            }

            return View(animaisachados);
        }

        // GET: Animaisachados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animaisachados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnimalAchado,Foto,DescricaoFoto,Especie,Raca,AchadorNome,AchadorTelefone,Bairro,Detalhes")] Animaisachados animaisachados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animaisachados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animaisachados);
        }

        // GET: Animaisachados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisachados = await _context.Animaisachados.FindAsync(id);
            if (animaisachados == null)
            {
                return NotFound();
            }
            return View(animaisachados);
        }

        // POST: Animaisachados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimalAchado,Foto,DescricaoFoto,Especie,Raca,AchadorNome,AchadorTelefone,Bairro,Detalhes")] Animaisachados animaisachados)
        {
            if (id != animaisachados.IdAnimalAchado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animaisachados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaisachadosExists(animaisachados.IdAnimalAchado))
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
            return View(animaisachados);
        }

        // GET: Animaisachados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisachados = await _context.Animaisachados
                .FirstOrDefaultAsync(m => m.IdAnimalAchado == id);
            if (animaisachados == null)
            {
                return NotFound();
            }

            return View(animaisachados);
        }

        // POST: Animaisachados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animaisachados = await _context.Animaisachados.FindAsync(id);
            _context.Animaisachados.Remove(animaisachados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimaisachadosExists(int id)
        {
            return _context.Animaisachados.Any(e => e.IdAnimalAchado == id);
        }
    }
}
