using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SiteCCZ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using X.PagedList;

namespace SiteCCZ.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AnimaiscczController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AnimaiscczController(Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Animaisccz
        public async Task<IActionResult> Index(string filtro, string pesquisa, int? pagina)
        {
            if (pesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                pesquisa = filtro;
            }
            ViewData["Filtro"] = pesquisa;

            var animais = from a in _context.Animaisccz select a;   

            if (!String.IsNullOrEmpty(pesquisa))
            {
                animais = animais.Where(a => a.Nome.Contains(pesquisa)).AsNoTracking();
            }

            int itensPorPagina = 5;

            return View(await animais.ToPagedListAsync(pagina, itensPorPagina));
        }



        // GET: Animaisccz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisccz = await _context.Animaisccz
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animaisccz == null)
            {
                return NotFound();
            }
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(animaisccz);
        }

        // GET: Animaisccz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animaisccz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnimal,Especie,Sexo,Nome,Foto,IdadeAprox,Porte,Cor,Raca,Historia,StatusAnimal,Adotavel")] Animaisccz animaisccz, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto!= null)
                    {
                        string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\animaisccz");
                        var nomeArquivo = Guid.NewGuid().ToString() + " " + Foto.FileName;
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await Foto.CopyToAsync(stream);
                        };
                        animaisccz.Foto = "/img/animaisccz/" + nomeArquivo;
                    }

                _context.Add(animaisccz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animaisccz);
        }

        // GET: Animaisccz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisccz = await _context.Animaisccz.FindAsync(id);
            if (animaisccz == null)
            {
                return NotFound();
            }
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(animaisccz);
        }

        // POST: Animaisccz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimal,Especie,Sexo,Nome,Foto,IdadeAprox,Porte,Cor,Raca,Historia,StatusAnimal,Adotavel")] Animaisccz animaisccz, IFormFile NovaFoto)
        {
            if (id != animaisccz.IdAnimal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NovaFoto!= null)
                {
                    string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\animaisccz");
                    var nomeArquivo = Guid.NewGuid().ToString() + " " + NovaFoto.FileName;
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await NovaFoto.CopyToAsync(stream);
                    };
                    animaisccz.Foto = "/img/animaisccz/" + nomeArquivo;
                }
                    _context.Update(animaisccz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaiscczExists(animaisccz.IdAnimal))
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
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(animaisccz);
        }

        // GET: Animaisccz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animaisccz = await _context.Animaisccz
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animaisccz == null)
            {
                return NotFound();
            }

            return View(animaisccz);
        }

        // POST: Animaisccz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animaisccz = await _context.Animaisccz.FindAsync(id);
            _context.Animaisccz.Remove(animaisccz);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool AnimaiscczExists(int id)
        {
            return _context.Animaisccz.Any(e => e.IdAnimal == id);
        }
    }
}
