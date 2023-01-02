using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerObligatorio;
using System;
using System.Collections.Generic;

namespace AppMundial.Controllers
{
    public class OperadorController : Controller
    {
        Sistema s = Sistema.GetSistema();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Nombre = HttpContext.Session.GetString("nombre");
            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            return View();
        }

        public IActionResult Partidos()
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            List<Partido> Finalizado = s.GetPartidosFinalizados();
            ViewBag.NoFinalizados = s.GetPartidosNoFinalizados();

            return View(Finalizado);
        }


        public IActionResult Estadisticas()
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            ViewBag.ExistenReseñas = false;
            ViewBag.SeleccionConMasGoles = s.GetSeleccionesConMasGoles();
            return View();
        }

        [HttpPost]
        public IActionResult Estadisticas(string email)
        {
            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            ViewBag.SeleccionConMasGoles = s.GetSeleccionesConMasGoles();
            List<Partido> _ret = s.GetPartidosReseñasPeriodistaTRoja(email);

            if (_ret.Count == 0)
            {
                ViewBag.Error = "No existen reseñas para este periodista";
            }
            
            return View(_ret);  
        }


        public IActionResult FinalizacionPartido(int id)
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            s.GetPartido(id).FinalizacionPartido();

            List<Jugador> ListaJugadores = s.GetJugadoresDePartidoConIncidencias(id);

            ViewBag.Jugadores = ListaJugadores;

            Partido _ret = s.GetPartido(id);

            if (_ret is FaseGrupo)
            {
                ViewBag.EsFase = true;
                FaseGrupo __ret = _ret as FaseGrupo;
                ViewBag.Fase = __ret;
            }
            else if (_ret is FaseEliminatoria)
            {
                ViewBag.EsFase = false;
                FaseEliminatoria __ret = _ret as FaseEliminatoria;
                ViewBag.Fase = __ret;
            }
            return View();
        }


        public IActionResult Periodistas()
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            List<Periodista> _ret = s.GetPeriodistas();
            return View(_ret);
        }

        public IActionResult Reseñas(int id)
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");
            ViewBag.Periodista = s.GetPeriodista(id).Nombre + " " + s.GetPeriodista(id).Apellido;
            List<Reseña> _ret = s.GetReseñasPeriodista(id);
            return View(_ret);
        }

        public IActionResult FiltrosDePartido(string error)
        {
            if (HttpContext.Session.GetString("tipo") != "OPERADOR")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = error;
            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            return View();
        }

        [HttpPost]
        public IActionResult FiltrosDePartido(DateTime d1, DateTime d2)
        {
            ViewBag.Tipo = HttpContext.Session.GetString("tipo");
            ViewBag.Nombre = HttpContext.Session.GetString("nombre");

            if (d1 > d2)
            {
                return RedirectToAction("FiltrosDePartido","Operador", new { error = "La segunda fecha debe de ser mayor o igual a la primera. Verifique" });
            }
            else
            {
                List<Partido> _ret = s.GetPartidosFinalizadosEntre(d1, d2);
                if (_ret.Count == 0)
                {
                    return RedirectToAction("FiltrosDePartido", "Operador", new { error = "No existen partidos finalizados en el periodo establecido" });
                }
                return View(_ret);
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }
}
