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
            return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult Login(usuarios userDataFromPost)
        {

            UsuarioRepository usuarioRepository = new UsuarioRepository();
            usuarios usuario = usuarioRepository.findByUserName(userDataFromPost.nombre_usuario);

            if (usuario != null && usuario.clave == userDataFromPost.clave)
            {
                TempData["Usuario"] = usuario;
                Session["User"] = usuario;
                if(usuario.personas.tipo_persona == TipoPersona.Docente)
                {
                    return new RedirectResult("~/Docente");

                } else
                {
                    return View("Alumno", usuario);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "No pudimos validar su usuario y/o contraseña. Intente nuevamente.";
                return View("Index");
            }
        }

        public ActionResult Inscripciones(int id)
        {
            IEnumerable<alumnos_inscripciones> inscripciones = uRepository.getInscripcionesAlumno(id);
            return View(inscripciones);
        }
    }
}
