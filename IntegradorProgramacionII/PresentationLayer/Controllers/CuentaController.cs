using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;

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
            if (username == "admin" && password == "12345")
            {
                return RedirectToAction("Index", "Home");
                //return View();
            }
            else {
                return RedirectToAction("ErrorLogin", "Cuenta");
            }
        }

        public ActionResult ErrorLogin()
        {
            CuentaViewModel error = new CuentaViewModel();
            error.ErrorLogin = "Usuario Incorrecto";

            return View(error);
        }


    }
}
