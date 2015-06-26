using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegradorProgramacionII.Classes;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            Croupier c = Session["game"] as Croupier;

            vm.dinero = c.Jugador.Efectivo;
            vm.nombre = c.Jugador.Nombre;
            vm.apellido = c.Jugador.Apellido;
            vm.email = c.Jugador.Email;
            vm.avatar = c.Jugador.Avatar;
            // este action es para comprar fichas
            return View(vm);
        }

        public ActionResult Jugar() 
        {
            return View();
        }

        public ActionResult Menu()
        {
            Croupier c = Session["game"] as Croupier;
            return View();
        }

    }
}
