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
    public class HomeController : Controller
    {
        private readonly Contexto _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {            
            IndexViewModel model = new IndexViewModel();
            model.Postblog = await _context.Postsblog.OrderByDescending(p => p.DataPublicacao).Take(3).ToListAsync();
            model.AnimalPerdido = await _context.Animaisperdidos.OrderByDescending(a => a.IdAnimalPerdido).Take(3).ToListAsync();
            model.Animal = await _context.Animaisccz.OrderByDescending(a => a.IdAnimal).Take(3).ToListAsync();
            
            return View(model);
        }

        public async Task<IActionResult> Adocao()
        {
            return View(await _context.Animaisccz.ToListAsync());
        }

        public IActionResult Blog()
        {
            return View();
        }

        public async Task<IActionResult> CadeMeuPet()
        {
            CademeupetViewModel model = new CademeupetViewModel();
            model.AnimalAchado = await _context.Animaisachados.OrderByDescending(a => a.IdAnimalAchado).ToListAsync();
            model.AnimalPerdido = await _context.Animaisperdidos.OrderByDescending(a => a.IdAnimalPerdido).ToListAsync();
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
