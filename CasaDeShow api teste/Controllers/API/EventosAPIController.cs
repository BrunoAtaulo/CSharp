using System.Linq;
using Microsoft.EntityFrameworkCore;
using CasaDeShow.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CasaDeShow.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        private readonly UserManager<IdentityUser> _userManager;

        public EventosAPIController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult GET()
        {
            var eventos = database.Evento.ToList();
            return Ok(eventos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] eventoTemp etemp){
            Evento e = new Evento();
            e.NomeEvento = etemp.NomeEvento;
            e.Capacidade = etemp.Capacidade;
            e.Data = etemp.Data;
            e.ValorIngresso = etemp.ValorIngresso;
            e.Casadeshow = database.Casadeshow.First(p => p.Id == etemp.CasadeshowId);
            e.GeneroMusica = etemp.GeneroMusica;
            database.Evento.Add(e);
            database.SaveChanges();
            return Ok("incluido");
        }

        [HttpGet("{id}")]
        public IActionResult GET(int id)
        {
            var eventos = database.Evento.First(p => p.Id == id);
            return Ok(eventos);
        }


        public class eventoTemp{
        public int Id { get; set; }
        public string NomeEvento { get; set; }
        public int Capacidade { get; set; }
        public System.DateTime Data { get; set; }
        public double ValorIngresso { get; set; }
        public string GeneroMusica { get; set; }
        public int CasadeshowId { get; set; }
        }

    }
}