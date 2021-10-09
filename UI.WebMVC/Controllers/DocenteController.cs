using Academia.EntityFramework;
using Academia.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academia.Entities;

namespace UI.WebMVC.Controllers
{
    public class DocenteController : Controller

    {
        private DocenteCursoLogic DocenteCursoLogic;
        public DocenteCursoRepository dcRepository { get; set; }
        public DocenteController()
        {
            this.DocenteCursoLogic = new DocenteCursoLogic();
            dcRepository = new DocenteCursoRepository();
        }
        // GET: Docente
        public ActionResult Index()
        {
            return View(this.DocenteCursoLogic.GetAll());
        }

        // GET: Docente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Docente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docente/Create
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

        // GET: Docente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Docente/Edit/5
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

        // GET: Docente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Docente/Delete/5
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

        public ActionResult Listado_cursos(int id_docente)
        {


            docentes_cursos doc_curso = dcRepository.Get(id_docente);

            return View("Listado_cursos", doc_curso);
             
        }
    }
}
