using Academia.Entities;
using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public class DocenteCursoLogic : BusinessLogic <docentes_cursos>
    {

        public DocenteCursoLogic()
        {
            this.repository = new DocenteCursoRepository();
        }
    }
}
