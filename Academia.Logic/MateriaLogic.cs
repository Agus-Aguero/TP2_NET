using Academia.Entities;
using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public class MateriaLogic: BusinessLogic <materias>
    {
        public MateriaLogic()
        {
            this.repository = new MateriaRepository();
        }
        public override IEnumerable<materias> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
