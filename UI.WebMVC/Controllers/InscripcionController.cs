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
    public class InscripcionController : Controller
    {
        public InscripcionRepository inscripcionRepository { get; set; }
        public DocenteCursoRepository docenteCursoRepository { get; set; }
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
        public ActionResult Edit(List<alumnos_inscripciones> inscripcionesAlumnos)
        {
            List<int> rowId = new List<int>();
            try
            {
                var idCurso = inscripcionesAlumnos.FirstOrDefault().id_curso;

                foreach (var item in inscripcionesAlumnos)
                {
                    switch (item.nota)
                    {
                        case 0:
                            item.condicion = EstadoAlumno.Inscripto.ToString();
                            inscripcionRepository.Update(item);
                            break;
                        case 1:
                        case 2:
                        case 3:
                            item.condicion = EstadoAlumno.Desaprobado.ToString();
                            inscripcionRepository.Update(item);
                            break;
                        case 4:
                        case 5:
                            item.condicion = EstadoAlumno.Regular.ToString();
                            inscripcionRepository.Update(item);
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            item.condicion = EstadoAlumno.Aprobado.ToString();
                            inscripcionRepository.Update(item);
                            break;
                        default:
                            rowId.Add(item.id_inscripcion);
                            break;
                    }
                }
                TempData["errorList"] = rowId;
                if(rowId.Count == 0)
                {
                    TempData["Success"] = "Actualización de curso exitosa.";

                } else
                {
                    TempData["Fail"] = "Actualización de notas OK. Revise los registros indicados, puede que existan notas inválidas.";
                }
                return Redirect("/Curso/AlumnosInscriptos?idCurso="+idCurso);

            }
            catch (Exception e)
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
