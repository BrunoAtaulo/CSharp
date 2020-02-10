using CasaDeShow.Data;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    public class HistoricoController : Controller
    {
        //----- Acessar banco de dados -----
        public readonly ApplicationDbContext database;

        public HistoricoController (ApplicationDbContext database)
        {
            this.database = database;
        }
        // ----------------------------------

        [Route("historico")]
         public IActionResult Historico()
        {
            return View();
        }
    }
}