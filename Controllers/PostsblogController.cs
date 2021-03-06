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
    public class PostsblogController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostsblogController(Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Postsblog
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPorPagina = 5;
            int numeroPagina = (pagina ?? 1);
            return View(await _context.Postsblog.ToPagedListAsync(numeroPagina, itensPorPagina));
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
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
        public async Task<IActionResult> Create([Bind("IdPostBlog,DataPublicacao,Autor,Conteudo,Foto,DescricaoImagem,Titulo,OlhoPost")] Postsblog postsblog, IFormFile Foto)
        {
                if (Foto!= null)
                    {
                        string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\postsblog");
                        var nomeArquivo = Guid.NewGuid().ToString() + " " + Foto.FileName;
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await Foto.CopyToAsync(stream);
                        };
                        postsblog.Foto = "/img/postsblog/" + nomeArquivo;
                    }
                _context.Add(postsblog);
                await _context.SaveChangesAsync();
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(postsblog);
        }

        // POST: Postsblog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPostBlog,DataPublicacao,Autor,Conteudo,Foto,DescricaoImagem,Titulo,OlhoPost")] Postsblog postsblog, IFormFile NovaFoto)
        {
            if (id != postsblog.IdPostBlog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NovaFoto != null)
                    {
                        string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\postsblog");
                        var nomeArquivo = Guid.NewGuid().ToString() + " " + NovaFoto.FileName;
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await NovaFoto.CopyToAsync(stream);
                        };
                        postsblog.Foto = "/img/postsblog/" + nomeArquivo;
                    }
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
