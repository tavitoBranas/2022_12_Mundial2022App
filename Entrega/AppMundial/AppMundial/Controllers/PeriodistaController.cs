using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerObligatorio;
using System;
using System.Collections.Generic;

namespace AppMundial.Controllers
{
    public class PeriodistaController : Controller
    {
        Sistema s = Sistema.GetSistema();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("tipo") != "PERIODISTA")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            return View();
        }


        public IActionResult PartidosFinalizados()
        {
            if (HttpContext.Session.GetString("tipo") != "PERIODISTA")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            List<Partido> partidosFinzalizados = s.GetPartidosFinalizados();
            return View(partidosFinzalizados);
        }


        public IActionResult Reseña(int id)
        {
            if (HttpContext.Session.GetString("tipo") != "PERIODISTA")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            Partido p = s.GetPartido(id);
            return View(p);
        }


        [HttpPost]
        public IActionResult Reseña(string contenido, string titulo, int id)
        {
            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            Partido p = s.GetPartido(id);
            try
            {
                Reseña r = new Reseña();
                r.ContenidoReseña = contenido;
                r.TituloReseña = titulo;
                r.Periodista = s.GetPeriodista(HttpContext.Session.GetInt32("id"));
                r.Partido = p;
                s.AltaResena(r);
                ViewBag.correcto = "Se realizo correctamente la reseña";
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View(p);
        }


        public IActionResult VisualizacionReseñas()
        {
            if (HttpContext.Session.GetString("tipo") != "PERIODISTA")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            List<Reseña> _ret = s.GetReseñasPeriodista(HttpContext.Session.GetInt32("id"));
            return View(_ret);
        }

    }
}
