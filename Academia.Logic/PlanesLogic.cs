using Academia.Entities;
using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public class PlanesLogic:BusinessLogic<planes>
    {
        public PlanesLogic()
        {
            this.repository = new PlanRepository();
        }
        public override planes Get(int ID)
        {
            return base.Get(ID);
        }
    }
}
