using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SiteCCZ.Models;

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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Adocao()
        {
            return View(await _context.Animaisccz.ToListAsync());
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult CadeMeuPet()
        {
            return View();
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
