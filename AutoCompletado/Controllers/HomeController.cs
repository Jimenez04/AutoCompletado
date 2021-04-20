using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoCompletado.Models;

namespace AutoCompletado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaNombre(string term)
        {
            List<Usuario> User = new List<Usuario>()
            {
                new Usuario{Id = 1, Nombre = "Jose Enrique"},
                new Usuario{Id = 2, Nombre = "Jose Garcia"},
                new Usuario{Id = 3, Nombre = "Jose Gabriel"},
                new Usuario{Id = 4, Nombre = "Jose Andres"},
                new Usuario{Id = 5, Nombre = "Josue Machado"}

            };

            var result = (from U in User
                          where U.Nombre.Contains(term, System.StringComparison.CurrentCultureIgnoreCase)
                          select new { value = U.Nombre }
                          );

            return Json(result);
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
