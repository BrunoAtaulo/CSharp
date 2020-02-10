using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasaDeShow.Models;
using CasaDeShow.Data;

namespace CasaDeShow.Controllers
{
    public class HomeController : Controller
    {
        /*
        //----- Acessar banco de dados -----
        public readonly ApplicationDbContext database;

        public HomeController (ApplicationDbContext database)
        {
            this.database = database;
        }
        // ----------------------------------
        */


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //----------------   Chamar as paginas   ----------------
        public IActionResult Index()
        {
            return View();
        }
        
       
        //[Route("historico")]
         public IActionResult Historico()
        {
            return View();
        }

        //------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
