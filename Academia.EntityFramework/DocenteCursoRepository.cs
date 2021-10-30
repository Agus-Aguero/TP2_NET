using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework
{
    public class DocenteCursoRepository : GenericRepository <docentes_cursos>
    {
        public override docentes_cursos Get(int id)

        {
            using (var context = new Academia())
            {

                return context.docentes_cursos.Where(docCur => docCur.id_dictado == id)
                                .Include(docCur => docCur.personas)
                                .Include(docCur => docCur.cursos).FirstOrDefault();
            }
        }

        public override IEnumerable<docentes_cursos> GetAll()
        {

            using (var context = new Academia())
            {

                return context.docentes_cursos.Include(docCur => docCur.cursos)
                                              .Include(docCur => docCur.cursos.materias)
                                              .Include(docCur => docCur.personas).ToList();
            }
        }

    }
}
