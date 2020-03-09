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
using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        // private readonly UserManager<IdentityUser> _userManager;

        public EventosAPIController(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Listar todos os eventos.
        /// </summary>
        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                var eventos = database.Evento.ToList();
                return Ok(eventos);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Eventos não localizados." });
            }
        }

        /// <summary>
        /// Criar evento.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] eventoTemp etemp)
        {
            try
            {
                Evento e = new Evento();
                e.NomeEvento = etemp.NomeEvento;
                e.Capacidade = etemp.Capacidade;
                e.Data = etemp.Data;
                e.ValorIngresso = etemp.ValorIngresso;
                e.Casadeshow = database.Casadeshow.First(p => p.Id == etemp.CasadeshowId);
                e.IngressosRestantes = etemp.Capacidade;
                switch (etemp.GeneroMusica)
                {
                    case 1:
                        e.GeneroMusica = "Rock";
                        break;
                    case 2:
                        e.GeneroMusica = "Pop";
                        break;
                    case 3:
                        e.GeneroMusica = "Pagode";
                        break;
                    case 4:
                        e.GeneroMusica = "Samba";
                        break;
                    case 5:
                        e.GeneroMusica = "Axe";
                        break;
                    case 6:
                        e.GeneroMusica = "Gospel";
                        break;
                    case 7:
                        e.GeneroMusica = "Forro";
                        break;
                    case 8:
                        e.GeneroMusica = "Funk";
                        break;
                    default:
                        e.GeneroMusica = "Rock";
                        break;
                }
                database.Evento.Add(e);
                database.SaveChanges();
                return Ok("Evento incluído com sucesso");
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Evento não cadastrado, favor verificar as informações e tentar novamente." });
            }

        }

        /// <summary>
        /// Buscar evento pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GET(int id)
        {
            try
            {
                var eventos = database.Evento.First(p => p.Id == id);
                return Ok(eventos);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Evento não encontrado." });
            }
        }

        /// <summary>
        /// Editar evento pelo ID.
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] eventoTemp etemp, int id)
        {
            try
            {
                var ev = database.Evento.First(evtemp => evtemp.Id == etemp.Id);
                ev.NomeEvento = etemp.NomeEvento != null ? etemp.NomeEvento : ev.NomeEvento;
                ev.Capacidade = etemp.Capacidade != 0 ? etemp.Capacidade : ev.Capacidade;
                ev.Data = etemp.Data != null ? etemp.Data : ev.Data;
                ev.ValorIngresso = etemp.ValorIngresso != 0 ? etemp.ValorIngresso : ev.ValorIngresso;

                if (etemp.GeneroMusica != 0)
                {
                    switch (etemp.GeneroMusica)
                    {
                        case 1:
                            ev.GeneroMusica = "Rock";
                            break;
                        case 2:
                            ev.GeneroMusica = "Pop";
                            break;
                        case 3:
                            ev.GeneroMusica = "Pagode";
                            break;
                        case 4:
                            ev.GeneroMusica = "Samba";
                            break;
                        case 5:
                            ev.GeneroMusica = "Axe";
                            break;
                        case 6:
                            ev.GeneroMusica = "Gospel";
                            break;
                        case 7:
                            ev.GeneroMusica = "Forro";
                            break;
                        case 8:
                            ev.GeneroMusica = "Funk";
                            break;
                        default:
                            ev.GeneroMusica = "Rock";
                            break;
                    }
                }

                database.SaveChanges();
                // return Ok();
                return new ObjectResult(new { msg = "Evento editado com sucesso." });
            }
            catch (System.Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Deletar evento especifico.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var ev = database.Evento.First(evtemp => evtemp.Id == id);
                database.Evento.Remove(ev);
                database.SaveChanges();
                // return Ok();
                return new ObjectResult(new { msg = "Evento deletado com sucesso." });

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar capacidade em ordem crescente.
        /// </summary>
        [Route("Capacidade/ASC")]
        [HttpGet]
        public IActionResult CapacidadeASC()
        {
            try
            {
                var evento = database.Evento.OrderBy(evento => evento.Capacidade).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar capacidade em ordem decrescente.
        /// </summary>
        [Route("Capacidade/DESC")]
        [HttpGet]
        public IActionResult CapacidadeDESC()
        {
            try
            {
                var evento = database.Evento.OrderByDescending(evento => evento.Capacidade).ToList();
                return Ok(evento);

            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar data em ordem crescente.
        /// </summary>
        [Route("Data/ASC")]
        [HttpGet]
        public IActionResult DataASC()
        {
            try
            {
                var evento = database.Evento.OrderBy(evento => evento.Data).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar data em ordem decrescente.
        /// </summary>
        [Route("Data/DESC")]
        [HttpGet]
        public IActionResult DataDESC()
        {
            try
            {
                var evento = database.Evento.OrderByDescending(evento => evento.Data).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar evento em ordem crescente.
        /// </summary>
        [Route("Nome/ASC")]
        [HttpGet]
        public IActionResult NomeASC()
        {
            try
            {
                var evento = database.Evento.OrderBy(evento => evento.NomeEvento).ToList();
                return Ok(evento);

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar evento em ordem decrescente.
        /// </summary>
        [Route("Nome/DESC")]
        [HttpGet]
        public IActionResult NomeDESC()
        {
            try
            {
                var evento = database.Evento.OrderByDescending(evento => evento.NomeEvento).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar preco em ordem crescente.
        /// </summary>
        [Route("Preco/ASC")]
        [HttpGet]
        public IActionResult PrecoASC()
        {
            try
            {
                var evento = database.Evento.OrderBy(evento => evento.ValorIngresso).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        /// <summary>
        /// Listar preco em ordem decrescente.
        /// </summary>
        [Route("Preco/DESC")]
        [HttpGet]
        public IActionResult PrecoDESC()
        {
            try
            {
                var evento = database.Evento.OrderByDescending(evento => evento.ValorIngresso).ToList();
                return Ok(evento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Registro não localizado, favor verificar e tentar novamente." });
            }
        }

        public class eventoTemp
        {
            public int Id { get; set; }
            public string NomeEvento { get; set; }
            public int Capacidade { get; set; }
            public System.DateTime Data { get; set; }
            public double ValorIngresso { get; set; }
            public int GeneroMusica { get; set; }
            public int CasadeshowId { get; set; }
        }
    }
}