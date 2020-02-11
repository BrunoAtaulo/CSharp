using CasaDeShow.Data;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasasDeShow.Controllers
{
    [Authorize(Policy = "Gerenciador")]
    public class CasasdeshowController : Controller
    {
        //----- Acessar banco de dados -----
        public readonly ApplicationDbContext database;

        public CasasdeshowController(ApplicationDbContext database)
        {
            this.database = database;
        }
        // ----------------------------------


        [Route("casadeshow")]
        public IActionResult Casasdeshow()
        {
            return View();
        }

        // Cadastrar casa de show
        [HttpPost]
        public IActionResult Cadastrar(Casadeshow casadeshow)
        {
            //Procedimento para cadastrar evento e continuar na propria página após o cadastro

            database.Casadeshow.Add(casadeshow);
            database.SaveChanges();
            return RedirectToAction("Casasdeshow");

        }
    }
}