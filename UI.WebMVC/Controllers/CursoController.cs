using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academia.Entities;
using Academia.Logic;
using Academia.EntityFramework;

namespace UI.WebMVC.Controllers
{
    public class CursoController : Controller
    {
        public CursoRepository cursoRepository { get; set; }

        public CursoController()
        {
            cursoRepository = new CursoRepository();
        }
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            cursos curso = cursoRepository.Get(id);
            return View(curso);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
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

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Curso/Edit/5
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

        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curso/Delete/5
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

        public ActionResult AlumnosInscriptos(int idCurso)
        {
            IEnumerable<alumnos_inscripciones> alumnosInscriptos = cursoRepository.GetAlumnosInscriptos(idCurso);
            return View(alumnosInscriptos);
        }

        public ActionResult InscribirAlumno(int idAlumno, int idCurso)
        {
            alumnos_inscripciones inscripcion = cursoRepository.Inscribir(idAlumno, idCurso);
            return View("~/Views/Inscripcion/Inscripcion.cshtml",inscripcion);
        }

        public ActionResult InscribirDocente(int idDocente, int idCurso)
        {
            docentes_cursos inscripcion = cursoRepository.InscribirDocente(idDocente, idCurso);
            return View("~/Views/Docente/Inscripcion.cshtml", inscripcion);
        }
    }
}
