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
            //UsuarioRepository usuarioRepository = new UsuarioRepository();
            InscripcionRepository inscripcionRepository = new InscripcionRepository();
            
            //cursos curso = this.Get(idCurso);
            //usuarios usuario = usuarioRepository.Get(idAlumno);

            alumnos_inscripciones inscripcion = new alumnos_inscripciones();
            inscripcion.id_alumno = idAlumno;
            inscripcion.id_curso = idCurso;
            inscripcion.condicion = "Inscripto";
            inscripcion.nota = 0;

            inscripcionRepository.Insert(inscripcion);

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
