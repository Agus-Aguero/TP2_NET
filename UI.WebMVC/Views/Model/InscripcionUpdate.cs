using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia.Entities;

namespace UI.WebMVC.Views.Model
{
    public class InscripcionUpdate
    {
        List<alumnos_inscripciones> inscripcionAlumno;
        int id_alumno, id_curso, nota;
        string condicion;
        cursos curso;
        personas persona;
    }
}