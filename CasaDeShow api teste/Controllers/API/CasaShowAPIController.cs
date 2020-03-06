using System;
using System.Collections.Generic;
using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaShowAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        private readonly UserManager<IdentityUser> _userManager;

        public CasaShowAPIController(ApplicationDbContext database)
        {
            this.database = database;
        }

        // Lista todas as casas de show existentes
        [HttpGet]
        public IActionResult GET()
        {
            var casasdeshow = database.Casadeshow.ToList();
            return Ok(casasdeshow);
        }

        // Criar casa de show
        [HttpPost]
        public IActionResult Post([FromBody] CasaDeShowTemp casaTemp)
        {
            // Validação
            if (casaTemp.Nome.Length <= 5)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O casa de show precisa ter nome maior que 5 caracteres." });
            }

            if (casaTemp.Endereco.Length <= 5)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O endereço precisa ter mais que 5 caractere" });
            }

            Casadeshow c = new Casadeshow();
            c.Nome = casaTemp.Nome;
            c.Endereco = casaTemp.Endereco;
            database.Casadeshow.Add(c);

            // Salvando as alterações
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        // Busca casa de show pelo ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var casadeshow = database.Casadeshow.First(c => c.Id == id);

                return Ok(casadeshow);

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Casadeshow casadeshow)
        {
            if (casadeshow.Id > 0)
            {
                try
                {
                    var c = database.Casadeshow.First(ctemp => ctemp.Id == casadeshow.Id);
                    if (c != null)
                    {
                        // Editar usando condição ternária
                        c.Nome = casadeshow.Nome != null ? casadeshow.Nome : c.Nome;
                        c.Endereco = casadeshow.Endereco != null ? casadeshow.Endereco : c.Endereco;

                        // Salvando no banco de dados
                        database.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Registro não localizado" });
                    }

                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Registro não localizado" });
                }
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O Id do produto é inválido" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var casa = database.Casadeshow.First(casatemp => casatemp.Id == id);
                database.Casadeshow.Remove(casa);
                database.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [Route("ASC")]
        [HttpGet]
        public IActionResult ASC()
        {
            var casa = database.Casadeshow.ToList();
            return Ok(casa.OrderBy(casa => casa.Nome));
        }

        [Route("DESC")]
        [HttpGet]
        public IActionResult DESC()
        {
            var casa = database.Casadeshow.OrderByDescending(casa => casa.Nome).ToList();
            return Ok(casa);
        }

        [HttpGet("nome/" + "{nome}")]
        public IActionResult Nome(string nome)
        {
            var pesquisacasa = from c in database.Casadeshow
                               select c;

            if (!String.IsNullOrEmpty(nome))
            {
                pesquisacasa = pesquisacasa.Where(casa => casa.Nome.ToLower().Contains(nome.ToLower()));
            }
            return Ok(pesquisacasa.ToList());

        }

        public class CasaDeShowTemp
        {
            public string Nome { get; set; }
            public string Endereco { get; set; }
        }
    }
}