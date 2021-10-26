using Academia.Entities;
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

            return inscripcion;
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
    }
}
