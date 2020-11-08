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

namespace SiteCCZ.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AnimaiscczController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment _he;
        private readonly IConfiguration _config;

        public AnimaiscczController(Contexto context, IWebHostEnvironment he, IConfiguration config)
        {
            _context = context;
            _he = he;
            _config =config;
        }

        // GET: Animaisccz
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animaisccz.ToListAsync());
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

            var filename = "/img/" + id + ".jpg";
            ViewData["filelocation"] = filename;
            
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
        public async Task<IActionResult> Create([Bind("IdAnimal,Especie,Sexo,Nome,Foto,IdadeAprox,Porte,Cor,Raca,Historia,StatusAnimal,Adotavel")] Animaisccz animaisccz, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animaisccz);
                await _context.SaveChangesAsync();

                string l = animaisccz.IdAnimal + ".jpg";

                var caminho = _config.GetValue<string>("Upload:Imagens");

                var arquivo = Path.Combine(_he.WebRootPath, caminho, l);

                FileStream filestream = new FileStream(arquivo, FileMode.Create);
                pic.CopyTo(filestream);
                filestream.Close();


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

            var filename = "/img/" + id + ".jpg";
            ViewData["filelocation"] = filename;

            return View(animaisccz);
        }

        // POST: Animaisccz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimal,Especie,Sexo,Nome,Foto,IdadeAprox,Porte,Cor,Raca,Historia,StatusAnimal,Adotavel")] Animaisccz animaisccz, IFormFile pic)
        {
            if (id != animaisccz.IdAnimal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animaisccz);
                    await _context.SaveChangesAsync();

                    string l = animaisccz.IdAnimal + ".jpg";
                    var caminho = _config.GetValue<string>("Upload:Imagens");
                    var arquivo = Path.Combine(_he.WebRootPath, caminho, l);
                    System.IO.File.Delete(arquivo);

                    FileStream filestream = new FileStream(arquivo, FileMode.Create);
                    pic.CopyTo(filestream);
                    filestream.Close();
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

            var filename = "/img/" + id + ".jpg";
            ViewData["filelocation"] = filename;

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

            string l = animaisccz.IdAnimal + ".jpg";
            var caminho = _config.GetValue<string>("Upload:Imagens");
            var arquivo = Path.Combine(_he.WebRootPath, caminho, l);
            System.IO.File.Delete(arquivo);

            return RedirectToAction(nameof(Index));
        }

        private bool AnimaiscczExists(int id)
        {
            return _context.Animaisccz.Any(e => e.IdAnimal == id);
        }
    }
}
