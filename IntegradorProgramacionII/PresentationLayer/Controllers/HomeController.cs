using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegradorProgramacionII.Classes;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // este action es para comprar fichas
            return View();
        }

        public ActionResult Jugar() 
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

    }
}
