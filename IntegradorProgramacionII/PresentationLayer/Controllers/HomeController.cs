﻿using System;
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
            
            int pagar = c.Pagar();
            bool gano = false;
            if (pagar > 0)
                gano = true;
            c.Jugador.Guardar(c.Jugador.Id, pagar);
            c.Jugador = c.Jugador.Buscar(c.Jugador.User, c.Jugador.Pass);
            Session["game"] = c;
                  
            var json = Json(new
            {
                nombre = c.Jugador.Nombre,
                apellido = c.Jugador.Apellido,
                fichas = c.Jugador.Fichas,
                victorias = c.Jugador.Victorias,
                jugadas = c.Jugador.Jugadas,
                gano = gano,
                salio = Elegido,
                color = c.Ruleta.tablero[Elegido].Color,
            });
            return Json(json);
        }
 
        public ActionResult Comprar(int fichas)
        {
            Croupier c = Session["game"] as Croupier;
            
            c.Jugador.Comprar(c.Jugador.Id, fichas);
            c.Jugador = c.Jugador.Buscar(c.Jugador.User, c.Jugador.Pass);
            Session["game"] = c;

            var json = Json(new
            {
                fichas = c.Jugador.Fichas,
                dinero = c.Jugador.Efectivo
            });

            return Json(json);
        }


        public ActionResult Menu()
        {
            Croupier c = Session["game"] as Croupier;
            return View();
        }

    }
}
