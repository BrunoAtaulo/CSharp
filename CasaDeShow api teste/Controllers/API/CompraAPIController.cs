using CasaDeShow.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CasaDeShow.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        public CompraAPIController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult GET()
        {
            var compras = database.Compra.ToList();
            return Ok(compras);
        }

          // Busca Comprapelo ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var compra = database.Compra.First(c => c.Id == id);

                return Ok(compra);

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }


    }
}