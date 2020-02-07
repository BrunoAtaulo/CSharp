using System;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index(){
            return Content("Index");
        }
    }
}