using System.Linq;
using CasaDeShow.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CasaDeShow.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuariosAPIController(ApplicationDbContext database)
        {
            this.database = database;
        }

        //Lista todos os usuários
        [HttpGet]
        public IActionResult GET()
        {
            var usuarios = database.Users.ToList().Select(u => u.Id + "   " + u.Email);

            return Ok(usuarios);
        }


        [HttpGet("E-mail")]
        public IActionResult GET(string email)
        {
            var usuario = database.Users.ToList().First(u => u.Email == email);
            return Ok("Id: " + usuario.Id + "\nE-mail: "+usuario.Email);
        }
    }
}