using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_1.Database;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;
        public HomeController(ApplicationDBContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            /*
            Categoria c1 = new Categoria();
            c1.Nome = "Bruno";
            
            Categoria c2 = new Categoria();
            c2.Nome = "Fernanda";
            
            Categoria c3 = new Categoria();
            c3.Nome = "Esther";
            
            Categoria c4 = new Categoria();
            c4.Nome = "Elton";

            List<Categoria> catList = new List<Categoria>();
            catList.Add(c1);
            catList.Add(c2);
            catList.Add(c3);
            catList.Add(c4);

            database.AddRange(catList);

            database.SaveChanges();
            */

            //Ex.: Listar somente a categoria que o nome seja Bruno, a forma mais correta é utilizando .equals
            // var listaDeCategorias = database.Categorias.Where(cat => cat.Nome == "Bruno").ToList();
            // var listaDeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Bruno")).ToList();

            var listaDeCategorias = database.Categorias.ToList();

            System.Console.WriteLine("============ categorias ============");

            listaDeCategorias.ForEach(categoria =>
            {
                System.Console.WriteLine(categoria.ToString());
            });
            Console.WriteLine("================================");

            return Content("Dados salvos");

        }

        public IActionResult Relacionamento()
        {
            /*
            Produto p1 = new Produto();
            p1.Nome = "Doritos";
            p1.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p2 = new Produto();
            p2.Nome = "Bis";
            p2.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p3 = new Produto();
            p3.Nome = "Trento";
            p3.Categoria = database.Categorias.First(c => c.Id == 2);

            database.Add(p1);
            database.Add(p2);
            database.Add(p3);

            database.SaveChanges();
            */

            /*
            var listaDeProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            listaDeProdutos.ForEach(produto => {
                System.Console.WriteLine(produto.ToString());
            });
            */

            //Sem usar o include (LazyLoading). Obs.: LazyLoading pode tornar o sistema muito lento por isso sempre usar .Include em cadeias complexas
            // var listaDeProdutosDeUmaCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList();

            //Consula 1 para muitos (usando .Include)
            var listaDeProdutosDeUmaCategoria = database.Produtos.Include(p => p.Categoria).Where(p => p.Categoria.Id == 1).ToList();

            listaDeProdutosDeUmaCategoria.ForEach(produto =>
            {
                System.Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}