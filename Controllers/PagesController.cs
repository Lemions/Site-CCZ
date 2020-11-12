using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SiteCCZ.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View(adocao);
        }

        //POST: Contatoadocao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContatoadocao,IdAnimal,Nome,Email,Telefone,Justificativa")] Contatosadocao contatosadocao)
        {
            if (ModelState.Isvalid)
            {
                _context.Add(contatosadocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatosadocao);
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
