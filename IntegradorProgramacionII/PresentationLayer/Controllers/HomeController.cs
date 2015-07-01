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
            
            List<Casillero> numeros = new List<Casillero>();
            Casillero casilla;
            Apuesta bet;
            foreach (var item in apostado)
            {
                foreach (var num in item.numeros)
                {
                    casilla = new Casillero();
                    casilla.Valor = num;
                    if(num < 37)
                        casilla.Color = c.Ruleta.tablero[num].Color;
                    numeros.Add(casilla);
                }
                bet = new Apuesta(new List<Casillero>(numeros), item.fichas, new Modalidad(item.modalidad), c.Jugador);
                c.Ruleta.Apostar(bet);
                numeros.Clear();
            }
            
            //Actualizamos la DB
            //Si te sirve Marian, guarda en una variable el resultado de c.Pagar() si es mayor a cero, el flaco gano
            int pagar = c.Pagar();
            c.Jugador.Guardar(c.Jugador.Id, pagar);            

            if (pagar > 0 )
            {
                int salio = Elegido;
                string nombreCompleto = c.Jugador.Nombre + " " + c.Jugador.Apellido;

                var json = Json(new 
                { 
                    gano = true,
                    salio = salio, 
                    nombreCompleto = nombreCompleto 
                });

                return Json(json);                
            }
            
            var jason = Json(new {
                gano = false,
                perdiste = "Perdiste"
            });

            return Json(jason);
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
