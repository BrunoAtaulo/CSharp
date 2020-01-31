using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;
using MVC_1.Database;

namespace MVC_1.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database;
        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            //Mostra todos os funcionarios
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
            //Se quiser converter em lista tem que importar o "using System.Linq;"
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
            {
                //Salva novo funcionario
                database.Funcionarios.Add(funcionario);
            }
            else
            {
                //Atualizar funcionario
                Funcionario funcionarioDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Salario = funcionario.Salario;
                funcionarioDoBanco.Cpf = funcionario.Cpf;
            }

            database.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}