using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteCCZ.Models;
using SiteCCZ.ViewModel;

namespace SiteCCZ.Controllers
{
    public class PagesController : Controller
    {
        private readonly Contexto _context;
        private readonly ILogger<PagesController> _logger;

        public PagesController(ILogger<PagesController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult AdocaoDetalhes(int? id)
        {
            var animal = _context.Animaisccz.Find(id);
            var adocao = new AdocaoViewModel();
            adocao.Animal = animal;
            adocao.IdAnimal = id ?? 0;
            return View(adocao);
        }

 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdocaoDetalhes(AdocaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contato = new Contatosadocao()
                {
                    IdAnimal = model.IdAnimal,
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Justificativa = model.Justificativa
                };
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdocaoEmAnalise");
            }
            var animal = _context.Animaisccz.Find(model.IdAnimal);
            model.Animal = animal;
            return View(model);
        }

 

        public IActionResult AdocaoEmAnalise(AdocaoViewModel model)
        {
            return View(model);
        }

        public IActionResult CadeMeuPetDetalhes()
        {
            return View();
        }

        public IActionResult TesteNovoPost()
        {
            return View();
        }

        //GET: Postsblog
        public async Task<IActionResult> Post(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostblogViewModel model = new PostblogViewModel();
            model.PostBlogRecomendado = await _context.Postsblog.OrderByDescending(p => p.DataPublicacao).Take(3).ToListAsync();
            model.PostBlog = await _context.Postsblog
                .FirstOrDefaultAsync(m => m.IdPostBlog == id);
            if (model.PostBlog == null)
            {
                return NotFound();
            }

            var filename = "/img/postblog" + id + ".jpg";
            ViewData["filelocation"] = filename;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
