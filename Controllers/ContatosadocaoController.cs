using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteCCZ.Models;

namespace SiteCCZ.Controllers
{
    public class ContatosadocaoController : Controller
    {
        private readonly Contexto _context;

        public ContatosadocaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Contatosadocao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Contatosadocao.Include(c => c.IdAnimalNavigation);
            return View(await contexto.ToListAsync());
        }

        // GET: Contatosadocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatosadocao = await _context.Contatosadocao
                .Include(c => c.IdAnimalNavigation)
                .FirstOrDefaultAsync(m => m.IdContatoAdocao == id);
            if (contatosadocao == null)
            {
                return NotFound();
            }

            return View(contatosadocao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatosadocao = await _context.Contatosadocao
                .Include(c => c.IdAnimalNavigation)
                .FirstOrDefaultAsync(m => m.IdContatoAdocao == id);
            if (contatosadocao == null)
            {
                return NotFound();
            }

            return View(contatosadocao);
        }

        // POST: Contatosadocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contatosadocao = await _context.Contatosadocao.FindAsync(id);
            _context.Contatosadocao.Remove(contatosadocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatosadocaoExists(int id)
        {
            return _context.Contatosadocao.Any(e => e.IdContatoAdocao == id);
        }
    }
}
