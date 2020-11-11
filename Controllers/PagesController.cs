using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteCCZ.Models;

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
            return View(adocao);
        }

        public IActionResult CadeMeuPetDetalhes()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        public IActionResult TesteNovoPost()
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
