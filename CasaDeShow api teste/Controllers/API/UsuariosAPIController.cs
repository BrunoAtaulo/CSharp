using System;
using System.Linq;
using CasaDeShow.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CasaDeShow.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        // private readonly UserManager<IdentityUser> _userManager;

        public UsuariosAPIController(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Listar todos os usuario.
        /// </summary>
        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                var usuarios = database.Users.ToList().Select(u => u.Id + "   " + u.Email);
                return Ok(usuarios);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("Usuários não localizados.");
            }
        }

        /// <summary>
        /// Buscar pelo e-mail.
        /// </summary>
        [HttpGet("E-mail")]
        public IActionResult GET(string email)
        {
            try
            {
                var usuario = database.Users.ToList().First(u => u.Email == email);
                return Ok("Id: " + usuario.Id + "\nE-mail: " + usuario.Email);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("Registro não localizado, favor verificar e tentar novamente.");
            }
        }
    }
}