using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework
{
    public class MateriaRepository : GenericRepository<materias>
    {
        public override IEnumerable<materias> GetAll()
        {
            using (var context = new Academia())
            {
                IEnumerable<materias> materias = context.materias.Include(mat => mat.planes)
                                                                 .Include(mat => mat.cursos).ToList(); 
                return materias;
            }
        }

        public IEnumerable<cursos> GetCursos(int idMateria)
        {
            materias materia = this.Get(idMateria);
            return materia.cursos;
        }

        public override materias Get(int id)

        {
            using (var context = new Academia())
            {

                return context.materias.Where(mat => mat.id_materia == id)
                                .Include(mat => mat.cursos)
                                .FirstOrDefault();

            }
        }
    }
}
