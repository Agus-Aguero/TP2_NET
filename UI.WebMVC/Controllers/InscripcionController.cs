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
    public class InscripcionController : Controller
    {
        public InscripcionRepository inscripcionRepository { get; set; }
        public InscripcionController()
        {
            inscripcionRepository = new InscripcionRepository();
        }
        // GET: Inscripcion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inscripcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inscripcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inscripcion/Create
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

        // GET: Inscripcion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inscripcion/Edit/5
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

        // GET: Inscripcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inscripcion/Delete/5
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
    }
}
