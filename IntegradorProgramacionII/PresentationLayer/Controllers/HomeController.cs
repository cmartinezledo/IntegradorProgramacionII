using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegradorProgramacionII.Classes;
using PresentationLayer.Models;
using Newtonsoft.Json;

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
            vm.fichas = c.Jugador.Fichas;
            vm.partidas = c.Jugador.Jugadas;
            vm.victorias = c.Jugador.Victorias;
            vm.nombre = c.Jugador.Nombre;
            vm.apellido = c.Jugador.Apellido;
            vm.email = c.Jugador.Email;
            vm.avatar = c.Jugador.Avatar;
            vm.user = c.Jugador.User;
            // este action es para comprar fichas
            return View(vm);
        }
        public ActionResult RecibirApuesta(int Elegido, ApuestaViewModel[] apostado)
        {
            Croupier c = Session["game"] as Croupier;
            c.Elegido = Elegido;

            foreach (var item in apostado)
            {
                Modalidad modalidad = new Modalidad(item.modalidad);
                Casillero casillero = new Casillero();
                casillero.Valor = 3;//c.Ruleta.tablero[item.numero].Valor;
                casillero.Color = "Rojo";//c.Ruleta.tablero[item.numero].Color;
                
                Apuesta a = new Apuesta(casillero, item.dinero, modalidad, c.Jugador);
                c.Apuesta.Add(a);
            }

            c.Pagar();

            return View("Index", "Home");
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
