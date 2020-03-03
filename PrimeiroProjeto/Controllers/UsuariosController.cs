using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrimeiroProjeto.Data;
using PrimeiroProjeto.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;

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

                        // Chave de segurança (token)
                        string chavedeseguranca = "chave_de_seguranca_jwt";
                        // Encriptar a chave usando algoritmo simétrico (mesma chave para encriptar e decriptar)
                        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chavedeseguranca));
                        var credenciaisdeacesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

                        var JWT = new JwtSecurityToken(
                            issuer: "Bruno", // Quem fornece o JWT para o usuário
                            expires: DateTime.Now.AddHours(1), // 1 Hora a partir da data para expirar
                            audience: "usuario_comum", // Para quem é destinado o token
                            signingCredentials: credenciaisdeacesso
                        );
                        return Ok(new JwtSecurityTokenHandler().WriteToken(JWT));

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