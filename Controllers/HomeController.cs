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
using X.PagedList;

namespace SiteCCZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _logger = logger;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {            
            IndexViewModel model = new IndexViewModel();
            model.Postblog = await _context.Postsblog.OrderByDescending(p => p.DataPublicacao).Take(3).ToListAsync();
            model.AnimalPerdido = await _context.Animaisperdidos.OrderByDescending(a => a.IdAnimalPerdido).Take(3).ToListAsync();
            model.Animal = await _context.Animaisccz.OrderByDescending(a => a.IdAnimal).Take(3).ToListAsync();
            
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;

            return View(model);
        }

        public async Task<IActionResult> Adocao(int? pagina)
        {
            const int itensPorPagina = 8;
            int numeroPagina = (pagina ?? 1);
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            var animais = _context.Animaisccz.Where(a => a.Adotavel.Contains("Sim"));
            return View(await animais.ToPagedListAsync(numeroPagina, itensPorPagina));
        }

        public async Task<IActionResult> Blog(int? pagina)
        {
            const int itensPorPagina = 6;
            int numeroPagina = (pagina ?? 1);
            var postsblog = await _context.Postsblog.ToPagedListAsync(numeroPagina, itensPorPagina);
            ViewData["Caminho"] = webHostEnvironment.WebRootPath;
            return View(postsblog);
        }

        public async Task<IActionResult> CadeMeuPet()
        {
            CademeupetViewModel model = new CademeupetViewModel();
            model.AnimalAchado = await _context.Animaisachados.OrderByDescending(a => a.IdAnimalAchado).ToListAsync();
            model.AnimalPerdido = await _context.Animaisperdidos.OrderByDescending(a => a.IdAnimalPerdido).ToListAsync();

            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(model);
        }

        public IActionResult Denuncias()
        {
            return View();
        }

        public IActionResult QuemSomos()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
