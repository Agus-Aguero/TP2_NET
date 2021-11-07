using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework
{
    public class ComisionRepository : GenericRepository<comisiones>
    {
        public override IEnumerable<comisiones> GetAll()
        {
            using (var context = new Academia())
            {
                return context.comisiones.Include(com => com.planes).ToList();
            }
        }

    }
}
