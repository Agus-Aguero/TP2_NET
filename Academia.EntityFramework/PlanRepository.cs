using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Entities;
using System.Data.Entity.Migrations;

namespace Academia.EntityFramework
{
    public class PlanRepository : GenericRepository<planes>
    {
        public override void Update(planes entityToUpdate)
        {
            using (var context = new Academia())
            {

                context.planes.AddOrUpdate(entityToUpdate);
                context.SaveChanges();

            }
        }

    }
}
