using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Academia.Entities;
using Academia.EntityFramework;
using Academia.Util;


namespace Academia.Logic
{
    public class CursoLogic : BusinessLogic <cursos>
    {
        public CursoRepository CursoRepository { get; set; }
        public CursoLogic()
        {
            this.repository = new CursoRepository();
            this.CursoRepository = new CursoRepository();
        }
        public override IEnumerable<cursos> GetAll()
        {
            return repository.GetAll();
        }
        public void Inscribir(int idAlumno,int idCurso)
        {
            this.CursoRepository.Inscribir(idAlumno, idCurso);
        }
        public void EliminarInscripcion(int idAlumno, int idCurso)
        {
            this.CursoRepository.EliminarInscripcion(idAlumno, idCurso);
        }
    }
}
