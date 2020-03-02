using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Data;
using PrimeiroProjeto.Models;
using PrimeiroProjeto.HATEOAS;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PrimeiroProjeto.Controllers
{
    [Route("api/v1/[controller]")]
    // [Route("api/PegarProdutos")]
    // [Authorize]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        // Injetando banco de dados no controller para poder salvar no MySQL
        private readonly ApplicationDbContext database;
        private HATEOAS.HATEOAS HATEOAS;
        public ProdutosController(ApplicationDbContext database)
        {
            this.database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5001/api/v1/Produtos");
            HATEOAS.AddAction("GET_INFO","GET");
            HATEOAS.AddAction("DELETE_PRODUCT","DELETE");
            HATEOAS.AddAction("EDIT_PRODUCT","PATCH");
        }


        // Listando todos os produtos
        [HttpGet]
        public IActionResult Get()
        {
            var produtos = database.Produtos.ToList();
            List<ProdutoContainer> produtosHATEOAS = new List<ProdutoContainer>();
            foreach (var prod in produtos)
            {
                ProdutoContainer produtoHATEOAS = new ProdutoContainer();
                produtoHATEOAS.produto = prod;
                produtoHATEOAS.links = HATEOAS.GetActions(prod.Id.ToString());
                produtosHATEOAS.Add(produtoHATEOAS);
            }
            return Ok(produtosHATEOAS); //Retornar JSON
        }


        // Listando produto específico
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var produto = database.Produtos.First(p => p.Id == id);
                // Colocando o HATEOAS
                ProdutoContainer produtoHATEOAS = new ProdutoContainer();
                produtoHATEOAS.produto = produto;
                produtoHATEOAS.links = HATEOAS.GetActions(produto.Id.ToString());

                return Ok(produtoHATEOAS);

            }
            catch (Exception e)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
                // return BadRequest(new { msg = "Id inválido" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var produto = database.Produtos.First(p => p.Id == id);
                database.Produtos.Remove(produto);
                database.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        // [HttpPost]
        // public IActionResult Post()
        // {
        //     return Ok("Tudo normal"); //Exemplo normal de POST
        // }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoTemp pTemp)
        {
            // Validação
            if (pTemp.Preco <= 0)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O preço do produto não pode ser igual ou menor que 0." });
            }

            if (pTemp.Nome.Length <= 1)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O nome do produto precisa ter mais que 1 caractere" });
            }


            Produto p = new Produto();
            p.Nome = pTemp.Nome;
            p.Preco = pTemp.Preco;
            database.Produtos.Add(p);

            // Salvando as alterações
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
            // return Ok(new { msg = "Produto criado com sucesso!" });
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Produto produto)
        {
            if (produto.Id > 0)
            {
                try
                {
                    var p = database.Produtos.First(pTemp => pTemp.Id == produto.Id);
                    if (p != null)
                    {
                        // Editar
                        // Condição ternária
                        p.Nome = produto.Nome != null ? produto.Nome : p.Nome;
                        p.Preco = produto.Preco > 0 ? produto.Preco : p.Preco;

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



        //Criando classe dentro do controller para teste, ideal é criar um outro arquivo
        public class ProdutoTemp
        {
            public string Nome { get; set; }
            public float Preco { get; set; }
        }

        public class ProdutoContainer
        {
            public Produto produto { get; set; }
            public Link[] links { get; set; }
        }
    }
}