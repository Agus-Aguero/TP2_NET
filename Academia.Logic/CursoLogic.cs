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
        public CursoLogic()
        {
            this.repository = new CursoRepository();
        }
        public override IEnumerable<cursos> GetAll()
        {
            return repository.GetAll();
        }
    }
}
