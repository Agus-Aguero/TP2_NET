using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academia.Entities;
using Academia.Logic;
using Academia.EntityFramework;
using Academia.Util;

namespace UI.WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioLogic uLogic { get; set; }
        public UsuarioRepository uRepository { get; set; }
        public UsuarioController()
        {
            uLogic = new UsuarioLogic();
            uRepository = new UsuarioRepository();
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View("Alumno");
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Inscripciones(int id)
        {
            var usuario = (usuarios)Session["User"];

            if(usuario.personas.tipo_persona == TipoPersona.Alumno)
            {
                IEnumerable<alumnos_inscripciones> inscripcionesAlumno = uRepository.getInscripcionesAlumno(id);
                return View(inscripcionesAlumno);
            }

            IEnumerable<docentes_cursos> inscripcionesDocente = uRepository.getInscripcionesDocente(id);
            return View("../Docente/Inscripciones", inscripcionesDocente);
        }
    }
}
