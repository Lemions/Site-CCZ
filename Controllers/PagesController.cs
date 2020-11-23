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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SiteCCZ.Controllers
{
    public class PagesController : Controller
    {
        private readonly Contexto _context;
        private readonly ILogger<PagesController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PagesController(ILogger<PagesController> logger, Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _logger = logger;
            webHostEnvironment = hostEnvironment;
        }


        public IActionResult AdocaoDetalhes(int? id)
        {
            var animal = _context.Animaisccz.Find(id);
            var adocao = new AdocaoViewModel();
            adocao.Animal = animal;
            adocao.IdAnimal = id ?? 0;

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;

            return View(model);
        }

 

        public IActionResult AdocaoEmAnalise(AdocaoViewModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> AnimalAchadoDetalhes(int? id)
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(animaisachados);
        }

        public IActionResult CadastrarAnimalAchado()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarAnimalAchado([Bind("IdAnimalAchado,Foto,DescricaoFoto,Especie,Raca,AchadorNome,AchadorTelefone,Bairro,Detalhes")] Animaisachados animaisachados, IFormFile Foto)
        {
            if (ModelState.IsValid) 
            {
                if (Foto!= null)
                {
                    string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\animaisachados");
                    var nomeArquivo = Guid.NewGuid().ToString() + " " + Foto.FileName;
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await Foto.CopyToAsync(stream);
                    };
                    animaisachados.Foto = "/img/animaisachados/" + nomeArquivo;
                }

                _context.Add(animaisachados);
                await _context.SaveChangesAsync();
                return View(animaisachados);
            }
                return View(animaisachados);
        }

        public async Task<IActionResult> AnimalPerdidoDetalhes(int? id)
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(animaisperdidos);
        }

        public IActionResult CadastrarAnimalPerdido()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarAnimalPerdido([Bind("IdAnimalPerdido,Nome,Especie,Raca,Foto,TelefoneDono,Detalhes")] Animaisperdidos animaisperdidos, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto!= null)
                {
                    string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\animaisperdidos");
                    var nomeArquivo = Guid.NewGuid().ToString() + " " + Foto.FileName;
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await Foto.CopyToAsync(stream);
                    };
                    animaisperdidos.Foto = "/img/animaisperdidos/" + nomeArquivo;
                }

                _context.Add(animaisperdidos);
                await _context.SaveChangesAsync();
                return View(animaisperdidos);
            }
                return View(animaisperdidos);
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

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
