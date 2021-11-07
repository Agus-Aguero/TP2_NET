﻿using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academia.EntityFramework
{
    public class CursoRepository : GenericRepository<cursos>
    {

        public docentes_cursos InscribirDocente(int idDocente, int idCurso)
        {

            cursos curso = this.Get(idCurso);
            DocenteCursoRepository inscripcionRepository = new DocenteCursoRepository();

            docentes_cursos inscripcion = new docentes_cursos();
            inscripcion.id_docente = idDocente;
            inscripcion.id_curso = curso.id_curso;

            inscripcionRepository.Insert(inscripcion);

            return inscripcion;
        }
        public alumnos_inscripciones Inscribir(int idAlumno, int idCurso)
        {

            cursos curso = this.Get(idCurso);

            InscripcionRepository inscripcionRepository = new InscripcionRepository();

            alumnos_inscripciones inscripcion = new alumnos_inscripciones();
            inscripcion.id_alumno = idAlumno;
            inscripcion.id_curso = idCurso;
            inscripcion.condicion = "Inscripto";
            inscripcion.nota = 0;

            inscripcionRepository.Insert(inscripcion);

            curso.cupo--;
            this.Update(curso);

            inscripcion.cursos = curso;

            return inscripcion;
        }

        public void EliminarInscripcion(int idAlumno, int idCurso)
        {
            using (var context = new Academia())
            {

                List<alumnos_inscripciones> inscripciones = context.alumnos_inscripciones
                                                                   .Where(aluIns => aluIns.id_curso == idCurso && aluIns.id_alumno == idAlumno)
                                                                   .ToList();
                context.alumnos_inscripciones.RemoveRange(inscripciones);

                cursos curso = this.Get(idCurso);
                curso.cupo++;
                this.Update(curso);

                context.SaveChanges();

            }

        }

        public override cursos Get(int id)
        {
            using (var context = new Academia())
            {
                return context.cursos.Where(cur => cur.id_curso == id)
                                .Include(cur => cur.comisiones)
                                .Include(cur => cur.materias)
                                .Include(cur => cur.docentes_cursos).FirstOrDefault();
            }
        }

        public List<alumnos_inscripciones> GetAlumnosInscriptos(int idCurso)
        {
            using (var context = new Academia())
            {
                return context.alumnos_inscripciones.Where(insc => insc.id_curso == idCurso)
                                .Include(insc => insc.personas)
                                .Include(insc => insc.cursos).ToList();
            }
        }

        public override IEnumerable<cursos> GetAll()
        {
            using (var context = new Academia())
            {
                var hola =  context.cursos
                                .Include(cur => cur.comisiones)
                                .Include(cur => cur.materias)
                                .Include(cur => cur.docentes_cursos).ToList();
                return hola;
                
            }
        }
    }
}
