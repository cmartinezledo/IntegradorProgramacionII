﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using IntegradorProgramacionII.Classes;

namespace PresentationLayer.Controllers
{
    public class CuentaController : Controller
    {
        //
        // GET: /Cuenta/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            Player player = new Player();
            if (player.ValidarLogin(username, password))
            {
                Session["game"] = new Croupier(player.Buscar(username, password));

                return RedirectToAction("Index", "Home");
                //return View();
            }
            else {
                return RedirectToAction("ErrorLogin", "Cuenta");
            }
        }

        public ActionResult Signup(string nombre, string apellido, string email, string username, string password, int avatar)
        {
            Player nuevo = new Player();

            nuevo.Nombre = nombre;
            nuevo.Apellido = apellido;
            nuevo.Email = email;
            nuevo.User = username;
            nuevo.Pass = password;
            nuevo.Avatar = avatar;

            nuevo.SignUp(nuevo);
            //Crear usuario en la base de datos
            return View();
        }

        public ActionResult ErrorLogin()
        {
            CuentaViewModel error = new CuentaViewModel();
            error.ErrorLogin = "Usuario Incorrecto";

            return View(error);
        }


    }
}
