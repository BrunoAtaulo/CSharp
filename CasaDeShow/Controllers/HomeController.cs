using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasaDeShow.Models;
using CasaDeShow.Data;
using Microsoft.EntityFrameworkCore;

namespace CasaDeShow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext database;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database)
        {
            _logger = logger;
            this.database = database;
        }

        public async Task<IActionResult> Index()
        {
            return View(await database.Evento.ToListAsync());
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
