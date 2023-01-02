using AppMundial.Models;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PrimerObligatorio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppMundial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //genero sistema y trabajo como singleton
        Sistema s = Sistema.GetSistema();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("tipo") != null)
            {
                if (HttpContext.Session.GetString("tipo") == "OPERADOR")
                {
                    return RedirectToAction("Index", "Operador");
                }
                else
                {
                    return RedirectToAction("Index", "Periodista");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, string contraseña)
        {
            ViewBag.error = null;

            Usuario u = s.LogIn(usuario, contraseña);

            if (u == null)
            {
                ViewBag.error = "Error de ingreso. Corrobore usuario y contraseña";
            }
            else
            {
                if (u is Operador)
                {
                    HttpContext.Session.SetString("nombre", u.Nombre + " " + u.Apellido);
                    HttpContext.Session.SetInt32("id", u.Id);
                    HttpContext.Session.SetString("tipo", "OPERADOR");
                    return RedirectToAction("Index", "Operador");
                }
                else
                {
                    HttpContext.Session.SetString("nombre", u.Nombre + " " + u.Apellido);
                    HttpContext.Session.SetInt32("id", u.Id);
                    HttpContext.Session.SetString("tipo", "PERIODISTA");
                    return RedirectToAction("Index", "Periodista");
                }
            }
            return View();
        }

        //view de listado de selecciones
        public IActionResult ListadoSelecciones(string tipo, string nombre)
        {
            ViewBag.Tipo = tipo;
            ViewBag.Nombre = nombre;

            List<Seleccion> _ret = s.GetSelecciones();
            return View(_ret);
        }

        //view para registro de periodistas

        public IActionResult RegistroPeriodistas()
        {
            if (HttpContext.Session.GetString("tipo") != null)
            {
                if (HttpContext.Session.GetString("tipo") == "OPERADOR")
                {
                    return RedirectToAction("Index", "Operador");
                }
                else
                {
                    return RedirectToAction("Index", "Periodista");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult RegistroPeriodistas(Periodista p, bool Acepta)
        {
            try
            {
                if (Acepta)
                {
                    s.AltaPeriodista(p);
                    //limpio los campos luego de que fue exitoso
                    ModelState.Clear();
                    ViewBag.correcto = "Su registro se realizo correctamente";
                }
                else
                {
                    ViewBag.error = "Necesita confirmar que Acepta Terminos y Condiciones";
                }
            }
            catch (Exception e)
            {

                ViewBag.error = e.Message;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
