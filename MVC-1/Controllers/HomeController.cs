using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_1.Database;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;
        public HomeController(ApplicationDBContext database)
        {
            this.database = database;
        }
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Teste()
        {
            Categoria c1 = new Categoria();
            c1.Nome = "Bruno Ataulo";
            
            Categoria c2 = new Categoria();
            c2.Nome = "Fernanda";
            
            Categoria c3 = new Categoria();
            c3.Nome = "Esther";
            
            Categoria c4 = new Categoria();
            c4.Nome = "Elton";

            List<Categoria> catList = new List<Categoria>();
            catList.Add(c1);
            catList.Add(c2);
            catList.Add(c3);
            catList.Add(c4);

            catList.AddRange(catList);

            database.SaveChanges();

            return Content("Dados salvos");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}