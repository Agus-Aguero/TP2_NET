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
    public class MateriaController : Controller
    {
        public MateriaLogic mLogic { get; set; }
        public MateriaRepository mRepository { get; set; }

        public MateriaController()
        {
            mLogic = new MateriaLogic();
            mRepository = new MateriaRepository();
        }

        // GET: Materia
        public ActionResult Index()
        {
            var materias = mLogic.GetAll();
            return View(materias);
        }

        // GET: Materia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
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

        // GET: Materia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materia/Edit/5
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

        // GET: Materia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materia/Delete/5
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

        public ActionResult Cursos(int idMateria)
        {
            IEnumerable<cursos> cursos = mRepository.GetCursos(idMateria);
            return View(cursos);
        }

        public ActionResult InscribirUsuario()
        {
            IEnumerable<alumnos_inscripciones> inscripciones;
            return View("Inscripciones");
        }
    }
}
