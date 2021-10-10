using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Entities;

namespace Academia.EntityFramework
{
    public class PersonaRepository : GenericRepository<personas>
    {
        public personas GetByLegajo(int nroLegajo)
        {
            using (var context = new Academia())
            {
                return context.personas.Where(per => per.legajo == nroLegajo).FirstOrDefault();
            }
        }
    }
}
