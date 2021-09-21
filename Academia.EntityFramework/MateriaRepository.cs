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
    }
}
