using System;
using CasaDeShow.Data;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    [Authorize]
    public class EventosController : Controller
    {
        //----- Acessar banco de dados -----
        public readonly ApplicationDbContext database;

        public EventosController (ApplicationDbContext database)
        {
            this.database = database;
        }
        // ----------------------------------

        [Route("eventos")]
         public IActionResult Eventos()
        {
            // return View("_Layout2");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Evento evento)
        {
            //Procedimento para cadastrar evento
            database.Evento.Add(evento);
            database.SaveChanges();
            return Content("Evento cadastrado!");
            // return RedirectToAction("eventos");
        }
    }
}