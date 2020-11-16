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
    public class PostsblogController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment _he;
        private readonly IConfiguration _config;

        public PostsblogController(Contexto context, IWebHostEnvironment he, IConfiguration config)
        {
            _context = context;
            _he = he;
            _config =config;
        }

        // GET: Postsblog
        public async Task<IActionResult> Index()
        {
            return View(await _context.Postsblog.ToListAsync());
        }

        // GET: Postsblog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsblog = await _context.Postsblog
                .FirstOrDefaultAsync(m => m.IdPostBlog == id);
            if (postsblog == null)
            {
                return NotFound();
            }

            var filename = "/img/postblog" + id + ".jpg";
            ViewData["filelocation"] = filename;

            return View(postsblog);
        }

        // GET: Postsblog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postsblog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPostBlog,DataPublicacao,Autor,Conteudo,Imagem,DescricaoImagem,Titulo,OlhoPost")] Postsblog postsblog, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postsblog);
                await _context.SaveChangesAsync();

                string l = postsblog.IdPostBlog + ".jpg";

                var caminho = _config.GetValue<string>("Upload:ImagensPost");

                var arquivo = Path.Combine(_he.WebRootPath, caminho, l);

                FileStream filestream = new FileStream(arquivo, FileMode.Create);
                pic.CopyTo(filestream);
                filestream.Close();

                return RedirectToAction(nameof(Index));
            }
            return View(postsblog);
        }

        // GET: Postsblog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsblog = await _context.Postsblog.FindAsync(id);
            if (postsblog == null)
            {
                return NotFound();
            }
            return View(postsblog);
        }

        // POST: Postsblog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPostBlog,DataPublicacao,Autor,Conteudo,Imagem,DescricaoImagem,Titulo,OlhoPost")] Postsblog postsblog)
        {
            if (id != postsblog.IdPostBlog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postsblog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsblogExists(postsblog.IdPostBlog))
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
            return View(postsblog);
        }

        // GET: Postsblog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsblog = await _context.Postsblog
                .FirstOrDefaultAsync(m => m.IdPostBlog == id);
            if (postsblog == null)
            {
                return NotFound();
            }

            return View(postsblog);
        }

        // POST: Postsblog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postsblog = await _context.Postsblog.FindAsync(id);
            _context.Postsblog.Remove(postsblog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsblogExists(int id)
        {
            return _context.Postsblog.Any(e => e.IdPostBlog == id);
        }
    }
}
