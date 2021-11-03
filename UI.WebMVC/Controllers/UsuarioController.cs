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
        public PersonaRepository pRepository { get; set; }
        public UsuarioController()
        {
            uLogic = new UsuarioLogic();
            uRepository = new UsuarioRepository();
            pRepository = new PersonaRepository();

        }
        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = (usuarios)Session["User"];
            
            switch (usuario.personas.tipo_persona)
            {
                case TipoPersona.Alumno:
                    return View("Alumno");
                case TipoPersona.Docente:
                    return View("../Docente/Docente");
                default:
                    return View("../Home/Index");
            }
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
            personas persona = pRepository.Get(id);
            return View(persona);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, personas persona)
        {
            try
            {
                personas personaAux = pRepository.Get(persona.id_persona);

                personaAux.nombre = persona.nombre;
                personaAux.apellido = persona.apellido;
                personaAux.direccion = persona.direccion;
                personaAux.email = persona.email;
                personaAux.telefono = persona.telefono;
                personaAux.fecha_nac = persona.fecha_nac;

                pRepository.UpdateMVC(personaAux);
                TempData["Success"] = "Perfil editado satisfactoriamente.";

                return RedirectToAction("Index");
            }
            catch(Exception e)
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
