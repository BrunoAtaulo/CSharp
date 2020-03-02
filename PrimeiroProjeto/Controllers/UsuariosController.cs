using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Data;
using PrimeiroProjeto.Models;

namespace PrimeiroProjeto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public UsuariosController(ApplicationDbContext database)
        {
            this.database = database;
        }
        //api/v1/usuarios/registro
        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Usuario usuario)
        {
            database.Add(usuario);
            database.SaveChanges();
            return Ok(new { msg = "usuario cadastrado com sucesso" });
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario credenciais)
        {
            try
            {
                // Buscar usuario por e-mail e verificar se a senha está ok
                Usuario usuario = database.Usuarios.First(user => user.Email.Equals(credenciais.Email));

                if (usuario != null)
                {
                    // Achou um usuario com o cadastro válido
                    if (usuario.Senha.Equals(credenciais.Senha))
                    {
                        // Usuário acertou a senha e logou
                        return Ok("Logado"); //Gerar token JWT
                    }
                    else
                    {
                        // Não existe usuário com este e-mail
                        Response.StatusCode = 401;
                        return new ObjectResult("");
                    }
                }
                else
                {
                    // Não existe usuário com este e-mail
                    Response.StatusCode = 401;
                    return new ObjectResult("");
                }
            }
            catch (System.Exception e)
            {
                // Não existe usuário com este e-mail
                Response.StatusCode = 401;
                return new ObjectResult("");
            }

        }
    }
}